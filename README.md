# docker-aspnet

## Installation with docker

### Stop Port 1433

_Before, you should liberate the port 1433 if you used already a MSSQL Server_

```bash
$ NET STOP MSSQL$SQLEXPRESS03
```

`SQLEXPRESS03` is the name of your instance.

### Add your MSSQL Server

_Install the MSSQL server with `docker-compose` command_

```bash
$ docker-compose up -d
```

### Replace your connection string

_After that, you should replace the connection string on `appsettings.json`_

```
Server=${IPMACHINE},1433;Database={DATABASENAME};User Id=sa;Password={PASSWORD};Integrated Security=False;MultipleActiveResultSets=True
```

### Variables

_You can change the variables by your own, these variables should be modify on the `docker-compose.yml` and into your connection string_

| NAME         | CURRENT          |
| :----------- | :--------------- |
| IPMACHINE    | 192.168.99.100   |
| DATABASENAME | master           |
| PASSWORD     | Your_password123 |

### Tips

_For find the ip machine, you should tap in your terminal_

```bash
$ docker-machine ip
```
