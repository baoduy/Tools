// This sample demonstrates the use of the WindowsIdentity class to impersonate a user.
// IMPORTANT NOTES:
// This sample can be run only on Windows XP.  The default Windows 2000 security policy
// prevents this sample from executing properly, and changing the policy to allow
// proper execution presents a security risk.
// This sample requests the user to enter a password on the console screen.
// Because the console window does not support methods allowing the password to be masked,
// it will be visible to anyone viewing the screen.
// The sample is intended to be executed in a .NET Framework 1.1 environment.  To execute
// this code in a 1.0 environment you will need to use a duplicate token in the call to the
// WindowsIdentity constructor. See KB article Q319615 for more information.

using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;
using System.Windows.Forms;

namespace AppPoolController.Class
{
    [assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, UnmanagedCode = true)]
    [assembly: PermissionSetAttribute(SecurityAction.RequestMinimum, Name = "FullTrust")]
    public static class Impersonation
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern bool CloseHandle(IntPtr handle);

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool DuplicateToken(IntPtr ExistingTokenHandle,
                                                 int SECURITY_IMPERSONATION_LEVEL,
                                                 ref IntPtr DuplicateTokenHandle);

        [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(String lpszUsername,
                                            String lpszDomain,
                                            String lpszPassword,
                                            int dwLogonType,
                                            int dwLogonProvider,
                                            ref IntPtr phToken);

        // Log On Types
        public const int LOGON32_LOGON_INTERACTIVE = 2;
        public const int LOGON32_LOGON_NETWORK = 3;
        public const int LOGON32_LOGON_NEW_CREDENTIALS = 9;

        // Log On Providers
        public const int LOGON32_PROVIDER_DEFAULT = 0;
        public const int LOGON32_PROVIDER_WINNT35 = 1;
        public const int LOGON32_PROVIDER_WINNT40 = 2;
        public const int LOGON32_PROVIDER_WINNT50 = 3;

        public const int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
        public const int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
        public const int FORMAT_MESSAGE_FROM_SYSTEM = 0x00001000;
    }
}