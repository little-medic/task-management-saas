import { useEffect, useState } from "react";
import api from "../services/api";

interface DashboardData {
    totalProjects: number;
    totalTasks: number;
    todoTasks: number;
    inProgressTasks: number;
    doneTasks: number;
}

function Dashboard() {
    const [data, setData] = useState<DashboardData | null>(null);

    useEffect(() => {
        api.get<DashboardData>("/Dashboard")
            .then((response) => {
                setData(response.data);
            });
    }, []);

    if (!data) {
        return <h1>Loading...</h1>;
    }

    return (
        <main>
            <h1>Task Management Dashboard</h1>

            <div className="card-container">
                <div className="card">
                    <h2>{data.totalProjects}</h2>
                    <p>Projects</p>
                </div>

                <div className="card">
                    <h2>{data.totalTasks}</h2>
                    <p>Total Tasks</p>
                </div>

                <div className="card">
                    <h2>{data.todoTasks}</h2>
                    <p>To Do</p>
                </div>

                <div className="card">
                    <h2>{data.inProgressTasks}</h2>
                    <p>In Progress</p>
                </div>

                <div className="card">
                    <h2>{data.doneTasks}</h2>
                    <p>Completed</p>
                </div>
            </div>
        </main>
    );
}

export default Dashboard;