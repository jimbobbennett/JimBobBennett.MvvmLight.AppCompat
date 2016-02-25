using System;
using System.Text;

namespace JimBobBennett.MvvmLight.AppCompat
{
    /// <summary>
    ///     Helper class for dispatcher operations on the UI thread in Android.
    /// </summary>
    /// <remarks>Original code by Laurent Bugnion</remarks>
    public static class AppcompatDispatcherHelper
    {
        /// <summary>
        ///     Executes an action on the UI thread. If this method is called
        ///     from the UI thread, the action is executed immendiately. If the
        ///     method is called from another thread, the action will be enqueued
        ///     on the UI thread's dispatcher and executed asynchronously.
        /// </summary>
        /// <param name="action">
        ///     The action that will be executed on the UI
        ///     thread.
        /// </param>
        // ReSharper disable InconsistentNaming
        public static void CheckBeginInvokeOnUI(Action action)
            // ReSharper restore InconsistentNaming
        {
            if (action == null)
            {
                return;
            }

            CheckDispatcher();
            AppCompatActivityBase.CurrentActivity.RunOnUiThread(action);
        }

        /// <summary>
        ///     This method is only here for compatibility with
        ///     other platforms but it doesn't do anything.
        /// </summary>
        public static void Initialize()
        {
        }

        /// <summary>
        ///     This method is only here for compatibility with
        ///     other platforms but it doesn't do anything.
        /// </summary>
        public static void Reset()
        {
        }

        private static void CheckDispatcher()
        {
            if (AppCompatActivityBase.CurrentActivity == null)
            {
                var error = new StringBuilder($"The {nameof(AppcompatDispatcherHelper)} cannot be called.");
                error.AppendLine();
                error.Append($"Make sure that your main Activity derives from {nameof(AppCompatActivityBase)}.");

                throw new InvalidOperationException(error.ToString());
            }
        }
    }
}