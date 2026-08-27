import { useEffect, useState } from "react";
import api from "../Services/api";

interface Project {
    id: number;
    name: string;
    description: string;
    createdAt: string;
}

function Projects() {
    const [projects, setProjects] = useState<Project[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        api.get<Project[]>("/Projects")
            .then((response) => {
                setProjects(response.data);
            })
            .catch(() => {
                setError("Could not load projects.");
            });
    }, []);

    return (
        <main>
        <div>
            <h1>Projects</h1>

            {error && <p>{error}</p>}

            {projects.map((project) => (
                <div key={project.id}>
                    <h2>{project.name}</h2>
                    <p>{project.description}</p>
                </div>
            ))}
            </div>
        </main>
    );
}

export default Projects;