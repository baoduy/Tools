# Config Encryption
As you know all sections in the config file of .Net application are protectable by using **ProtectedConfigurationProvider** when deploying the application to the Production environment. 

If you are using CI/CD to deploy your application, you can run the command [here](https://msdn.microsoft.com/en-us/library/bb986855.aspx) to encrypt/decrypt your config file.

However, for any reason, the deployment is still manually, and you want the deplorer help to encrypt your config files when he copies the files to the server then this is a tool for you. By default, the application will encrypt the App Settings and Configurations only.

Please note that the encrypted config file in particular server is not able to use on the other server as the encryption keys are identical.

# How to use Config Encrypt Tool.

1. Execute the tool and browse to your config file.
2. Specify the section name in combobox or the custom section name that you want to encrypt. Please note that the **All** option is **AppSettings and ConnectionSctrings** only.
3. Click corresponding Encrypt and Decrypt button for your actions.

![Image](https://raw.githubusercontent.com/baoduy/Images/master/Tools/EncryptConfigFile/EncryptConfigTool.PNG)

# Source Code

https://github.com/baoduy/Tools