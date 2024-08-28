import {createContext, useContext, useState} from "react";

export const AuthContext = createContext();

export const useAuth = () => useContext(AuthContext);

export default function AuthProvider({children}) {

    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [username, setUsername] = useState(null);
    const valueToBeShared = {isAuthenticated, setIsAuthenticated, login, logout, username};

    function login(username, password) {
        const result = username === "in28minutes" && password === "dummy";
        setIsAuthenticated(result);
        if (result){
            setUsername(username);
        } else {
            setUsername(null);
        }
        return result;
    }

    function logout() {
        setIsAuthenticated(false);
    }
    
    return (
        <AuthContext.Provider value={valueToBeShared}>
            {children}
        </AuthContext.Provider>
    )
}