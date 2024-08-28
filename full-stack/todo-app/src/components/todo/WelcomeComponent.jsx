import {Link, useParams} from "react-router-dom";


export default function WelcomeComponent() {
    const {username} = useParams();

    return (
        <div className={"Welcome"}>
            <h2>Welcome {username}</h2>
            <div>
                Manage your todos - <Link to="/todos">Go here</Link>
            </div>
        </div>

    )
}