# Demo - Emulator atmoz/sftp

Demo showing how can configure multiple users and directories in a sftp server using the atmoz/sftp image.

[atmoz/sftp](https://github.com/atmoz/sftp)


## Environment Variables
`<username1>:<password1>:<uid1>:<gid1>:<dir1_1>,<dir1_2>{space}<username2>:<password2>:<uid2>:<gid2>:<dir2_1>,<dir2_2>`


```yml
  sftp-server:
    image: atmoz/sftp:alpine
    ...
    environment:
      SFTP_USERS: demouser:demopass:::inbox,sent mockuser:mockpass:::mock-inbox,mock-sent fakeuser:fakepass:::fake-inbox,fake-sent
    ...
```
