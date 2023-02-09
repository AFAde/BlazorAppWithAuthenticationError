using System.Threading;
using System;

namespace BlazorAppWithAuthentication
{
    public class BlazorServiceAccessor
    {
        private static readonly AsyncLocal<BlazorServiceHolder> CurrentServiceHolder = new();

        public IServiceProvider? Services
        {
            get => CurrentServiceHolder.Value?.Services;
            set
            {
                if (CurrentServiceHolder.Value is { } holder)
                {
                    // Clear the current IServiceProvider trapped in the AsyncLocal.
                    holder.Services = null;
                }

                if (value is not null)
                {
                    // Use object indirection to hold the IServiceProvider in an AsyncLocal
                    // so it can be cleared in all ExecutionContexts when it's cleared.
                    CurrentServiceHolder.Value = new() { Services = value };
                }
            }
        }

        private sealed class BlazorServiceHolder
        {
            public IServiceProvider? Services { get; set; }
        }
    }
}
