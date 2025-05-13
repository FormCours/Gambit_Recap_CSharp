namespace Demo_06_IntroASP.Services
{
    public class SingletonService
    {
        private static int _initializeCount = 0;

        private int _initializeCurrent = 0;
        public int InitializeCurrent => _initializeCurrent;

        public SingletonService()
        {
            _initializeCount++;
            _initializeCurrent = _initializeCount;
        }
    }
}
