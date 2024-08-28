<%@include file="common/header.jspf"%>
<%@include file="common/navigation.jspf"%>
<div class="container">
    <div>Your Todos</div>
    <table class="table">
        <thead>
        <tr>
            <th>id</th>
            <th>Description</th>
            <th>Target Date</th>
            <th>Is Done?</th>
            <th>DELETE</th>
            <th>UPDATE</th>
        </tr>
        </thead>
        <c:forEach items="${todos}" var="todo">
            <tr>
                <td>${todo.id}</td>
                <td>${todo.description}</td>
                <td>${todo.targetDate}</td>
                <td>${todo.done}</td>
                <td><a href="/delete-todo?id=${todo.id}" class="btn btn-warning">DELETE</a></td>
                <td><a href="/update-todo?id=${todo.id}" class="btn btn-success">UPDATE</a></td>
            </tr>
        </c:forEach>
    </table>
    <a href="/add-todo" class="btn btn-success">Add Todo</a>
</div>
<%@include file="common/footer.jspf"%>