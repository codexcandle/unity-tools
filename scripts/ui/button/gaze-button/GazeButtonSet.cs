using UnityEngine;
using UnityEngine.UI;

namespace Codebycandle.Util.Inpt
{
    public class GazeButtonSet:MonoBehaviour
    {
        [SerializeField] private GameObject[] buttons;

        public delegate void ClickAction(int index);
        public static event ClickAction OnClicked;

        private int activeBtnIndex;

        public void HandleClick(int btnIndex)
        {
            // update ui
            SelectButton(btnIndex);

            // dispatch event
            OnClicked(btnIndex);
        }

        private void Start()
        {
            // TODO - remove this temp hack & return button labels to match index
            string[] names = { "1", "1b", "2", "3", "4", "5", "6" };

            int length = buttons.Length;
            for (var i = 0; i < length; i++)
            {
                Text tComp = buttons[i].GetComponentInChildren<Text>();
                if (tComp != null)
                {
                    // tComp.text = (i + 1).ToString();

                    // TODO - remove below to make class generic!
                    tComp.text = names[i];
                }
            }

            // select 1st button
            SelectButton(activeBtnIndex);
        }

        private void SelectButton(int index)
        {
            // TODO - remove dependency to "vr" button!

            // deselect old
            if (activeBtnIndex > -1)
            {
                GazeButton activeBtn = buttons[activeBtnIndex].GetComponent<GazeButton>();
                activeBtn.Reset();
            }

            // select new
            GazeButton btn = buttons[index].GetComponent<GazeButton>();
            btn.MakeSelected();

            // save index
            activeBtnIndex = index;
        }
    }
}