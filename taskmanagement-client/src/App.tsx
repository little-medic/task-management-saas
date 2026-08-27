import { BrowserRouter, Routes, Route, Link } from "react-router-dom";
import Projects from "./Pages/Projects";
import Tasks from "./Pages/Tasks";
import Dashboard from "./Pages/Dashboard";

function App() {
    return (
        <BrowserRouter>
            <nav>
                <div className="nav-title">TaskFlow</div>

                <div className="nav-links">
                    <Link to="/">Dashboard</Link>
                    <Link to="/projects">Projects</Link>
                    <Link to="/tasks">Tasks</Link>
                </div>
            </nav>

            <Routes>
                <Route path="/" element={<Dashboard />} />
                <Route path="/projects" element={<Projects />} />
                <Route path="/tasks" element={<Tasks />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;