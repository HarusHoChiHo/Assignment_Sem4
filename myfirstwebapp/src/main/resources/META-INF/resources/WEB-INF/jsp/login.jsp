<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Login - Page</title>
</head>
<body>
<div class="container">
    <h1>Login</h1>
    <pre>${errorMessage}</pre>
    <form action="login" method="post">
        <label>
            Name:
            <input type="text" name="name"/>
        </label>
        <label>
            Password:
            <input type="password" name="password"/>
        </label>
        <input type="submit" value="Submit"/>
    </form>
</div>

</body>
</html>