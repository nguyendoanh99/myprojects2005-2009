using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace testSound
{
    public class Sound
    {
        [DllImport("WinMM.dll",
         EntryPoint = "PlaySound", CharSet = CharSet.Auto)]
        public static extern int PlaySoundWin32
        (string pszSound, int hmod, int fdwSound);

        [DllImport("CoreDll.dll",
         EntryPoint = "PlaySound", CharSet = CharSet.Auto)]
        public static extern int PlaySoundWinCE
        (string pszSound, int hmod, int fdwSound);
        private enum SND
        {
            SND_SYNC = 0x0000,
            /* play synchronously (default) */
            SND_ASYNC = 0x0001,
            /* play asynchronously */
            SND_NODEFAULT = 0x0002,
            /* silence (!default) if sound not found */
            SND_MEMORY = 0x0004,
            /* pszSound points to a memory file */
            SND_LOOP = 0x0008,
            /* loop the sound until next sndPlaySound */
            SND_NOSTOP = 0x0010,
            /* don't stop any currently playing sound */
            SND_NOWAIT = 0x00002000,
            /* don't wait if the driver is busy */
            SND_ALIAS = 0x00010000,
            /* name is a registry alias */
            SND_ALIAS_ID = 0x00110000,
            /* alias is a predefined ID */
            SND_FILENAME = 0x00020000,
            /* name is file name */
            SND_RESOURCE = 0x00040004,
            /* name is resource name or atom */
            SND_PURGE = 0x0040,
            /* purge non-static events for task */
            SND_APPLICATION = 0x0080
            /* look for application specific association */
        };
        private const int Win32 = 0;
        private const int WinCE = 1;
        private static int Windows = -1;
        public static void PlayMusic(string pszMusic)
        {
            int flags =
                (int)(SND.SND_ASYNC | SND.SND_FILENAME |
                      SND.SND_NOWAIT | SND.SND_LOOP);
            sndPlaySound(pszMusic, flags);
        }
        private static void sndPlaySound(string pszSound, int flags) 
        {
	        switch ( Windows ) 
	        {
		        case Win32 :
			        PlaySoundWin32(pszSound, 0, flags) ;
			        break ;
		        case WinCE :
			        PlaySoundWinCE(pszSound, 0, flags) ;
			        break ;
                default:
                    try // Play if in Win32 platform
                    {
                        PlaySoundWin32(pszSound, 0, flags);
                        Windows = Win32;
                    }
                    catch (Exception)
                    {
                        try // Play if in WinCE platform
                        {
                            PlaySoundWinCE(pszSound, 0, flags);
                            Windows = WinCE;
                        }
                        catch (Exception)
                        {
                        }
                    }
                    break;
            } // switch
        }
    }
}
