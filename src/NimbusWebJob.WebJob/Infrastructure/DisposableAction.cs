using System;

namespace NimbusWebJob.WebJob.Infrastructure
{
    public class DisposableAction : IDisposable
    {
        private readonly Action _action;

        public DisposableAction(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            if (_action != null)
            {
                _action();
            }
        }
    }
}