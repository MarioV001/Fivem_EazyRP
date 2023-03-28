using System;

namespace MyResource.Client
{
    internal class GameState
    {

        /// <summary>
        /// Details about the current hunt session.
        /// </summary>
        public static RobberyDetails Robbery { get; set; } = new RobberyDetails();

        /// <summary>
        /// Has the hunt been started?
        /// </summary>
        public static bool IsNewPlayer { get; set; } = true;
        public class RobberyDetails
        {
            /// <summary>
            /// Has the hunt been started?
            /// </summary>
            public bool IsStarted { get; set; } = false;

            /// <summary>
            /// Has the hunt finished?
            /// </summary>
            public bool IsOver { get; set; } = false;

            /// <summary>
            /// Is the hunt currently ongoing?
            /// </summary>
            public bool IsInProgress { get { return IsStarted && !IsOver; } }

            /// <summary>
            /// Is the hunt currently ending? (ie. winner notification being shown, etc.)
            /// </summary>
            public bool IsEnding { get { return !IsInProgress && IsOver; } }

            /// <summary>
            /// Can a hunt be started right now?
            /// </summary>
            public bool CanBeStarted { get { return !IsInProgress && !IsEnding; } }
        }
        /// <summary>
        /// Time when hunt is meant to end & state be reset.
        /// This includes the delay for displaying the win/loss text.
        /// </summary>
        public DateTime ActualEndTime { get; set; } = new DateTime();
    }
}
