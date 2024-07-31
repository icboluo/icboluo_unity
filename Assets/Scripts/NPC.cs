public class NPC : Interactable
{
    public string npcName;

    public string[] contentList;

    protected override void Interact()
    {
        DialogueUI.Instance.Show(npcName, contentList);
    }
}