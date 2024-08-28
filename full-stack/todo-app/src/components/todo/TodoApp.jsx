import "./TodoApp.css"
import {BrowserRouter, Navigate, Route, Routes} from "react-router-dom";
import LogoutComponent from "./LogoutComponent.jsx";
import FooterComponent from "./FooterComponent.jsx";
import HeaderComponent from "./HeaderComponent.jsx";
import ListTodosComponent from "./ListTodosComponent.jsx";
import ErrorComponent from "./ErrorComponent.jsx";
import WelcomeComponent from "./WelcomeComponent.jsx";
import LoginComponent from "./LoginComponent.jsx";
import AuthProvider, {useAuth} from "./security/AuthContext.jsx";
import TodoComponent from "./TodoComponent.jsx";

function AuthenticatedRoute({children}) {
    const {isAuthenticated} = useAuth();

    if (isAuthenticated) {
        return children
    } else {
        return <Navigate to={"/"} />
    }


}

export default function TodoApp() {
    return (
        <>
            <div className={"TodoApp"}>
                <AuthProvider>
                    <BrowserRouter>
                        <HeaderComponent />
                        <Routes>
                            <Route
                                path={"/"}
                                element={<LoginComponent />}
                            />
                            <Route
                                path={"/welcome/:username"}
                                element={<AuthenticatedRoute><WelcomeComponent /></AuthenticatedRoute>}
                            />
                            <Route
                                path={"/login"}
                                element={<LoginComponent />}
                            />
                            <Route
                                path={"/todos"}
                                element={<AuthenticatedRoute><ListTodosComponent /></AuthenticatedRoute>}
                            />
                            <Route
                                path={"/todo/:id"}
                                element={<AuthenticatedRoute><TodoComponent /></AuthenticatedRoute>}
                            />
                            <Route
                                path={"/logout"}
                                element={<LogoutComponent />}
                            />
                            <Route
                                path={"*"}
                                element={<ErrorComponent />}
                            />
                        </Routes>
                    </BrowserRouter>
                    <FooterComponent />
                </AuthProvider>
            </div>
        </>
    )
}

