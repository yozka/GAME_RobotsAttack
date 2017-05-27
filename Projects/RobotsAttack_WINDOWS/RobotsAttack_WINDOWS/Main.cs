using System;

namespace RobotsAttack_WINDOWS
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class AMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new AProgram())
                game.Run();
        }
    }
#endif
}
