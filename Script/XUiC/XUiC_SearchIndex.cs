using UnityEngine;
using System.Linq;
using System.Collections.Generic;


namespace SearchIndex
{
    public class XUiC_SearchIndex : XUiController
    {
        XUiC_TextInput searchField;

        TextInput backPackSearchField;
        TextInput lootContainerSearchField;

        public override void Init()
        {
            base.Init();
            searchField = GetChildById("indexSearchField") as XUiC_TextInput;
            if (searchField is null)
            {
                Log.Error("SearchIndex: Failed init of 'indexSearchField'");
                return;
            }

            searchField.OnChangeHandler += SearchLootField_OnChangeHandler;

            XUiC_BackpackWindow backPackParent = base.xui.GetChildByType<XUiC_BackpackWindow>();
            XUiC_LootWindow lootParent = base.xui.GetChildByType<XUiC_LootWindow>();

            if (backPackParent is null || lootParent is null)
            {
                Log.Error("SearchIndex: Failed init of 'parent' backPackParent or lootParent is null");
                return;
            }

            backPackParent.OnVisiblity += OnBackPackVisibility;
            
            backPackSearchField = backPackParent.GetChildById("backpackSearchField") as TextInput;
            lootContainerSearchField = lootParent.GetChildById("lootContainerSearchField") as TextInput;

            if (backPackSearchField is null || lootContainerSearchField is null)
                Log.Error("Failed init of 'backPackSearchField' or lootContainerSearchField");
            else
                Log.Out("SearchIndex successfully initialized");

        }


        private void OnBackPackVisibility(XUiController sender, bool _isVisible)
        {
            if (!_isVisible)
                searchField.UIInput.RemoveFocus();
            else
            {
                if (searchField is null || searchField.Text.IsNullOrWhiteSpace())
                    return;
                HighLightSearch(searchField.Text);
            }
        }


        private void HighLightSearch(string textInput)
        {
            backPackSearchField.Text = textInput;
            lootContainerSearchField.Text = textInput;

            backPackSearchField.TriggerChange();
            lootContainerSearchField.TriggerChange();
        }

        private void SearchLootField_OnChangeHandler(XUiController _sender, string _text, bool _changeFromCode)
        {

            XUiC_TextInput txtInput = _sender as XUiC_TextInput;

            if (txtInput is null || _changeFromCode)
                return;

            HighLightSearch(txtInput.Text);
        }


    }

}
