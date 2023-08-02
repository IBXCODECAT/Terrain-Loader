namespace PlayerInput
{
    public static class InputMapManager
    {
        private static ActionMap map = new ActionMap();

        public static ActionMap.BuildModeActions GetBuildModeActions()
        {
            map.BuildMode.Enable();
            return map.BuildMode;
        }

    }
}
