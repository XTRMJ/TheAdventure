using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogService : MonoBehaviour
{
    [System.Serializable]

    public struct MessageInfo
    {
        public string Message;

    }

    public static DialogService Instance;

    [SerializeField] Canvas _rootCanvas = null;
    [SerializeField] string _dialogPrebabName;
    DialogView _view = null;
    List<MessageInfo> _messages = new List<MessageInfo>();

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;
    }

    void LoadDialog()
    {
        if (_view != null) return;
        var go = Instantiate(Resources.Load<GameObject>(_dialogPrebabName));
        go.transform.SetParent(_rootCanvas.transform, false);
        _view = go.GetComponent<DialogView>();
        _view.OnPressed += ShowNextMessage; 
    }


    public void ShowDialogs(List<MessageInfo> messages)
    {
        Time.timeScale = 0f;
        LoadDialog();
        _messages.AddRange(messages);
        ShowNextMessage();

    }

    void ShowNextMessage()
    {
        if(_messages.Count < 1)
        {
            Time.timeScale = 1f;
            Destroy(_view.gameObject);
            return;
        }

        _view.Show(_messages[0].Message);
        _messages.RemoveAt(0);
    }

}
