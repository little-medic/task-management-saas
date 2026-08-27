import { useEffect, useState } from "react";
import api from "../Services/api";

interface TaskItem {
    id: number;
    title: string;
    description: string;
    status: string;
    priority: string;
    dueDate: string;
}

function Tasks() {
    const [tasks, setTasks] = useState<TaskItem[]>([]);
    const [error, setError] = useState("");

    useEffect(() => {
        api.get<TaskItem[]>("/Tasks")
            .then((response) => {
                setTasks(response.data);
            })
            .catch(() => {
                setError("Could not load tasks.");
            });
    }, []);

    return (
        <main>
        <div>
            <h1>Tasks</h1>

            {error && <p>{error}</p>}

            {tasks.map((task) => (
                <div key={task.id}>
                    <h2>{task.title}</h2>
                    <p>{task.description}</p>
                    <p>
                        <strong>Status:</strong> {task.status}
                    </p>
                    <p>
                        <strong>Priority:</strong> {task.priority}
                    </p>
                </div>
            ))}
            </div>
        </main>
    );
}

export default Tasks;