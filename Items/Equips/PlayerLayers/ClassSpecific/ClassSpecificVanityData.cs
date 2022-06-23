namespace CalValEX.Items.Equips.PlayerLayers.ClassSpecific
{
    public class ClassSpecificVanityData
    {
        public string PathToHead;
        public string PathToBody;
        public string HeadName;
        public string BodyName;

        /// <param name="pathToHead">The <b>folder path</b> to the head piece</param>
        /// <param name="pathToBody">The <b>folder path</b> to the body piece</param>
        /// <param name="headName">The <b>internal</b> item name of the head piece</param>
        /// <param name="bodyName">The <b>internal</b> item name of the body piece</param>
        public ClassSpecificVanityData(string pathToHead, string pathToBody, string headName, string bodyName)
        {
            PathToHead = pathToHead;
            PathToBody = pathToBody;
            HeadName = headName;
            BodyName = bodyName;
        }
    }
}
