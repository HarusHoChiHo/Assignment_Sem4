import {deleteTodoById, retrieveAllTodosForUsername} from "./api/TodoApiService.js";
import {useEffect, useState} from "react";
import {useAuth} from "./security/AuthContext.jsx";
import {useNavigate} from "react-router-dom";

export default function ListTodosComponent() {

    //const today = new Date();
    //const targetDate = new Date(today.getFullYear() + 12, today.getMonth(), today.getDay());
    const [todos, setTodos] = useState([]);
    const {username} = useAuth();
    // const todos = [
    //     {id: 1, description: "Learn AWS", done: false, target: targetDate},
    //     {id: 2, description: "Learn DevOps", done: false, target: targetDate},
    //     {id: 3, description: "Learn Full Stack Dev", done: false, target: targetDate}]

    const [message, setMessage] = useState();

    const navigate = useNavigate();
    
    useEffect(() => refreshTods(), []);


    function refreshTods() {
        retrieveAllTodosForUsername(username)
            .then(result => successfulResponse(result))
            .catch(error => errorResponse(error));
    }

    function successfulResponse(response) {
        //console.log(response);
        setTodos(response.data);
    }

    function errorResponse(error) {
        console.log(error);
    }

    function deleteTodo(username, id) {
        deleteTodoById(username, id)
            .then(result => {
                setMessage(`Delete of todo with ${id} successful`);
                console.log(result);
                refreshTods();
            })
            .catch(error => errorResponse(error));
    }

    function updateTodo(id) {
        navigate(`/todo/${id}`);
    }

    function addNewTodo() {
        navigate("/todo/-1")
    }

    return (
        <div className={"container"}>
            <h2>Things You Want To Do!</h2>
            {message && <div className={"alert alert-warning"}>{message}</div>}
            <div>
                <table className={"table"}>
                    <thead>
                        <tr>
                            <th>Description</th>
                            <th>Is Done?</th>
                            <th>Target Date</th>
                            <th>Delete</th>
                            <th>Update</th>
                        </tr>
                    </thead>
                    <tbody>
                        {todos.map(item =>
                            <tr key={item.id}>
                                <td>{item.description}</td>
                                <td>{item.done ? "Yes" : "No"}</td>
                                <td>{item.targetDate}</td>
                                <td>
                                    <button
                                        className={"btn btn-warning"}
                                        onClick={() => deleteTodo(item.username, item.id)}
                                    >Delete
                                    </button>
                                </td>
                                <td>
                                    <button
                                        className={"btn btn-success"}
                                        onClick={() => updateTodo(item.id)}
                                    >Update
                                    </button>
                                </td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
            <div className={"btn btn-success m-5"} onClick={addNewTodo}>Add New Todo</div>
        </div>
    )
}