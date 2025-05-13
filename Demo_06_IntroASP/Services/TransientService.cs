namespace Demo_06_IntroASP.Services
{
    public class TransientService
    {
        private static int _initializeCount = 0;

        private int _initializeCurrent = 0;
        public int InitializeCurrent => _initializeCurrent;

        public TransientService()
        {
            _initializeCount++;
            _initializeCurrent = _initializeCount;
        }
    }
}
