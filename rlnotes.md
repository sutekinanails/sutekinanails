# Logging in to Sutekina Nails' server

Here are the informations that you will need to login to the server. The server is a Ubuntu 18.04 Server machine running the latest version of Docker and NGinx as a proxy server. We will be using SSH to login to the server's command line and setup our docker containers there.

## SSH Access (command line)

* Server Address: dev.sutekinanails.com
* Username: rachel
* Password: *to be provided separately*
* Port: 2022
* Example login command: `ssh -p 2022 rachel@dev.sutekinanails.com`

Although optional, is it recommended that you follow the section below to login via public key for easier access and increased security. Make sure that you can login using your password first.

## Logging in via Public Key (optional, but recommended)

### 1. In your Mac terminal, type `ssh-keygen -b 4096`

You will be prompted for a location. You can use the default location (just press enter) or specify your own.

> **Warning**
> Make sure you don't overwrite any existing file, because you may break an existing connection if you do.

You will then be prompted to enter a passphrase. This step is optional, but recommended if you share your Mac with other people. If you specify a passphrase, you will be prompted for it every time you use the key to login using SSH.

You should then have two files at your specified location: id_rsa, which is your private key (do NOT share with anyone) and id_rsa.pub, which is your public key (that will be put on the server).

### 2. Run `ssh-copy-id -p 2022 rachel@dev.sutekinanails.com`

This command will copy your newly generated SSH key on the server for future authentication. You will be prompted for your SSH password and your keyfile password (if using).

### 3. Test logging in

Try logging in: `ssh -p 2022 rachel@dev.sutekinanails.com`. If it logs in without asking for a password (except your keyfile password if you specified one), you are good to go!

### 4. Set up an alias

In your Mac terminal, type `nano ~/.ssh/config`. An editor will open with a (possibly empty) file. Type the following information in the file:

```
Host sutekinanails
    HostName dev.sutekinanails.com
    User rachel
    Port 2022
```
Then, press `Ctrl+X` to exit, `Y` to save and `<Enter>` to accept the file name.

From now on, everytime you need to access the Sutekina Nails Server's command line, all you need to type is `ssh sutekinanails`. Neat, eh? OK, now let's get into the meat of things.

## Informations about this server

Before we delve further, let's see a few general informations about the server.

* You can use your home directory `/home/rachel` for personal file storage.
* If you need to store files for your 'public' web application, you may create a directory inside `/apps` for it.
* There is an instance of MongoDB available as a Docker container. It is of the latest version as of this writing. The port is `27017`. The physical location of the database is in `/data/db`.
* The website `https://dev.sutekinanails.com` proxies to the port `8080` on localhost. Make sure that your Node Express server is set on port `8080`.
* No need to worry about SSL, my NGinx proxy takes care of that for you!

## Running your Docker app

Once you have your image published on the Docker hub, you can run it on the server using the `docker run` command. Docker run will first pull the image from the hub and then create the container and run it. Since you will be destroying and re-creating the container a lot during the development of your application, a good practice would be to create a folder under `/apps` and mount your docker container's data volume there. So, for example, assuming your container's name is `sutekinanails` and your data is stored in `/data` in the container, a docker run command would look like this:

```bash
mkdir /apps/sutekina
docker run -v /apps/sutekina:/data -p 8080:8080 --restart unless-stopped -d sutekinanails:latest
```

Where:

* `-v` mounts the folder `/data` inside the container to `/apps/sutekina` on the server.
* `-p` maps the port `8080` from inside the container to the server.
* `--restart` specifies that we want the container to restart automatically unless we stop it ourselves. This is useful for when we have to reboot the server for e.g. security updates. Docker would then automatically restart the container for us. This is not good, however, if your application is still too unstable and crashes the container. Docker would then infinitely restart it in a loop!
* `-d` tell Docker that we want to run *detached*. When running detached, the container is run like a service, with no interaction possible from the user. Perfect when running on a server. On your development machine, however, you most likely would want to use the `-it` option instead, to run it *interactive* and be able to see the logs from your application.

This touches only the surface of all that is Docker. If you have any questions or need help during development, don't hesitate to reach out to me.

