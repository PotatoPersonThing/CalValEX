namespace CalValEX
{
    public class ClassSpecificPlayerLayer
    {
        public readonly ClassSpecificHeadPlayerLayer head;
        public readonly ClassSpecificMapPlayerLayer map;
        public readonly ClassSpecificBodyPlayerLayer body;

        public ClassSpecificPlayerLayer(string bodyPath, string headPath, string bodyName, string headName)
        {
            head = new ClassSpecificHeadPlayerLayer(headPath, headName);
            map = new ClassSpecificMapPlayerLayer(headPath, headName);
            body = new ClassSpecificBodyPlayerLayer(bodyPath, bodyName);
        }

        public bool Visible
        {
            get
            {
                return head.visible && map.visible && body.visible;
            }

            set
            {
                head.visible = value;
                map.visible = value;
                body.visible = value;
            }
        }
    }
}
