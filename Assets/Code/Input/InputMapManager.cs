namespace PlayerInput
{
    public static class InputMapManager
    {
        private static ActionMap map = new ActionMap();

        public static void EnableAllMaps()
        {
            map.BuildMode.Enable();
        }

        public static void DisableAllMaps()
        {
            map.BuildMode.Disable();
        }

        public static ActionMap.BuildModeActions GetBuildModeActions()
        {
            map.BuildMode.Enable();
            return map.BuildMode;
        }
    }
}
