import {useAuth} from "./security/AuthContext.jsx";
import {useNavigate, useParams} from "react-router-dom";
import {createTodo, retrieveTodoById, updateTodoById} from "./api/TodoApiService.js";
import {useEffect, useState} from "react";
import {ErrorMessage, Field, Form, Formik} from "formik";
import moment from "moment";

export default function TodoComponent() {

    const {username} = useAuth();
    const {id} = useParams();

    const [todo, setTodo] = useState();

    const navigate = useNavigate();

    const [description, setDescription] = useState("");
    const [targetDate, setTargetDate] = useState("");

    useEffect(() => {
        retrieveTodos()
    }, [id]);

    function retrieveTodos() {

        if (id === "-1") {
            return;
        }

        retrieveTodoById(username, id)
            .then(result => successfulResponse(result))
            .catch(error => errorResponse(error));
    }

    function successfulResponse(response) {
        //console.log(response);
        setTodo(response.data);
        setDescription(response.data.description);
        setTargetDate(response.data.targetDate);
    }

    function errorResponse(error) {
        console.log(error);
    }

    function onSubmit(values) {
        const todo = {
            id: id,
            username: username,
            description: values.description,
            targetDate: values.targetDate,
            done: false
        }
        if (id === "-1") {
            createTodo(username, todo)
                .then(result => {
                    console.log(result);
                    navigate("/todos");
                })
                .catch(error => errorResponse(error));

        } else {
            updateTodoById(username, id, todo)
                .then(result => {
                    console.log(result);
                    navigate("/todos");
                })
                .catch(error => errorResponse(error));
        }
    }

    function validate(values) {
        let errors = {
            // description: "Enter a valid description.",
            // targetDate: "Enter a valid date"
        }

        if (values.description.length < 5 || values.description === "")
            errors.description = "Enter at least 5 characters.";

        if (values.targetDate == null || values.targetDate === "" || !moment(values.targetDate).isValid())
            errors.targetDate = "Enter a target date.";

        return errors;
    }

    return (
        <div className={"container"}>
            <h1>Enter Todo Details</h1>
            <div>
                <Formik
                    initialValues={{description, targetDate}}
                    enableReinitialize={true}
                    onSubmit={onSubmit}
                    validate={validate}
                    validateOnChange={false}
                    validateOnBlur={false}
                >
                    {
                        (props) => (
                            <>
                                <ErrorMessage
                                    name={"description"}
                                    component={"div"}
                                    className={"alert alert-warning"}
                                />
                                <ErrorMessage
                                    name={"targetDate"}
                                    component={"div"}
                                    className={"alert alert-warning"}
                                />
                                <Form>
                                    <fieldset className={"form-group"}>
                                        <label>
                                            Description
                                        </label>
                                        <Field
                                            type={"text"}
                                            className={"form-control"}
                                            name={"description"}
                                        />
                                    </fieldset>
                                    <fieldset className={"form-group"}>
                                        <label>
                                            Target Date
                                        </label>
                                        <Field
                                            type={"date"}
                                            className={"form-control"}
                                            name={"targetDate"}
                                        />
                                    </fieldset>
                                    <div>
                                        <button
                                            className={"btn btn-success m-5"}
                                            type={"submit"}
                                        >Save
                                        </button>
                                    </div>
                                </Form>
                            </>
                        )
                    }
                </Formik>
            </div>
        </div>
    )
}