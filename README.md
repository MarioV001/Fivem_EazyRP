# EazyRP for CitizenFX

This EazyRP project has been Developet purely in C# for FiveM server by the CitizenFX api.


To build it, run `build.cmd`. To run it, run the following commands to make a symbolic link in your server data directory:

```dos
cd /d [PATH TO THIS RESOURCE]
mklink /d X:\cfx-server-data\resources\[local]\MyResource dist
```

Afterwards, you can use `ensure MyResource` in your server.cfg or server console to start the resource.# Fivem_EazyRP
