# CsRimeApi

Access the api of Rime[https://github.com/rime/librime] in c#


## build console sample from source on windows

.net version: 9.0

1.
go to `RimeApi.Console/rime_api_console.cs`, in the `run` method, find the following code:
`traits.user_data_dir = ...`

replace `...` with your user data directory, for example "D:/Program Files/Rime/User_Data"

2.
```bash
cd RimeApi.Console
# replace <your_runtime_identifier> with the identifier of your target runtime, e.g. win-x86
#win-x86 is for the rime.dll of 小狼毫0.15.0, if your rime.dll is 64bit, use win-x64 instead.
dotnet publish -c Release -r <your_runtime_identifier>
```

3.
prepare a copy or a hard link of `rime.dll` to the folder the same as `RimeApi.Console.exe`.
that is, put `rime.dll` at `RimeApi.Console/bin/Release/net10.0/<your_runtime_identifier>/publish`

4.
run the exe