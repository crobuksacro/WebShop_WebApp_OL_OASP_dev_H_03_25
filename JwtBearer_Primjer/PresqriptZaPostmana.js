var Username = 'webshopadmin@gmail.com';
var Password = 'Admin@123?';

pm.sendRequest({
    url: "https://localhost:7259/token",
    method: 'POST',
    header: {
        'Content-Type': 'application/json',
    },
    body: {
        mode: 'raw',
        raw: JSON.stringify({
            UserName: Username,
            Password: Password
        }),
        options: {
            raw: {
                language: 'json'
            }
        }
    }
}, function (err, res) {

    console.log(res.json().accessToken);
    pm.globals.set("token", res.json().accessToken);
})
