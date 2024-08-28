import {useState} from "react";
import {useNavigate} from "react-router-dom";
import {useAuth} from "./security/AuthContext.jsx";

export default function LoginComponent() {
    const [username, setUsername] = useState("in28minutes");
    const [password, setPassword] = useState("");
    const [showSuccessMsg, setShowSuccessMsg] = useState(false);
    const [showFailedMsg, setShowFailedMsg] = useState(false);
    const navigate = useNavigate();
    const {login} = useAuth();

    function handleUserName(event) {
        setUsername(event.target.value);
    }

    function handlePassword(event) {
        setPassword(event.target.value);
    }

    function handleSubmit() {
        if (login(username, password)) {
            navigate(`/welcome/${username}`);
        } else {
            setShowSuccessMsg(false);
            setShowFailedMsg(true);
        }
    }

    return (
        <div className={"Login"}>
            {showSuccessMsg && <div
                className={"successMessage"}
            >Authenticated Successfully</div>}
            {showFailedMsg && <div
                className={"errorMessage"}
                hidden={!showFailedMsg}
            >Authenticated Failed. Please check your credentials.</div>}
            <div className={"LoginForm"}>
                <div>
                    <label>
                        User Name
                    </label>
                    <input
                        type={"text"}
                        name={"username"}
                        value={username}
                        onChange={handleUserName}
                    />
                </div>
                <div>
                    <label>
                        Password
                    </label>
                    <input
                        type={"password"}
                        name={"password"}
                        value={password}
                        onChange={handlePassword}
                    />
                </div>
                <div>
                    <button
                        type={"button"}
                        name={"login"}
                        onClick={handleSubmit}
                    >Login
                    </button>
                </div>
            </div>
        </div>
    )
}