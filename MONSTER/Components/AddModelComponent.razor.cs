using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MONSTER.Models;
using MONSTER.Services;
using MudBlazor;
using System.Text.Json;
using static MudBlazor.Icons;

namespace MONSTER.Components
{
    public partial class AddModelComponent : ComponentBase
    {
        [Inject]
        public ISyncLocalStorageService _localStorage { get; set; }
        [Inject]
        private NavigationManager UriHelper { get; set; }

        private AssistantModel _am = new AssistantModel();
        private AssistantModel _newModel = new AssistantModel();
        List<AssistantModel> _modelList;

        string[] _iconList;
        protected override void OnParametersSet()
        {
            GetIconList();
            _modelList = _localStorage.GetItem<List<AssistantModel>>("Models");
            if (_modelList == null)
            {
                _modelList = new List<AssistantModel>();
            }
        }
        private void SaveModel()
        {           
            _modelList.Add(_am);
            _localStorage.SetItem<List<AssistantModel>>("Models", _modelList);
            UriHelper.NavigateTo($"/");
        }
        private void EditModel()
        {
            _localStorage.SetItem<List<AssistantModel>>("Models", _modelList);
            UriHelper.NavigateTo($"/");
        }

        private void GetIconList()
        {
            _iconList = new string[]{Icons.Material.Filled.Favorite, @Icons.Material.Filled.Api, @Icons.Material.Filled.AddCircle, @Icons.Custom.Brands.GitHub,
                @Icons.Custom.Brands.Google, @Icons.Custom.Brands.Reddit, @Icons.Custom.Uncategorized.Radioactive,
                @Icons.Material.Filled.ThumbUp, @Icons.Material.Filled.AppsOutage, @Icons.Material.Filled.Abc,
                @Icons.Material.Filled.AcUnit, @Icons.Material.Filled.AccessTime, @Icons.Material.Filled.Adjust,
                @Icons.Material.Filled.Agriculture, @Icons.Material.Filled.AirplanemodeActive, @Icons.Material.Filled.AlarmOn,
                @Icons.Material.Filled.AllInclusive, @Icons.Material.Filled.ArrowForward, @Icons.Material.Filled.AttachMoney,
                @Icons.Material.Filled.AutoFixHigh, @Icons.Material.Filled.Autorenew, @Icons.Material.Filled.BakeryDining, @Icons.Material.Filled.BlurOn,
                @Icons.Material.Filled.Brightness5, @Icons.Material.Filled.Cached, @Icons.Material.Filled.Camera, @Icons.Material.Filled.Chair,
                @Icons.Material.Filled.ChangeCircle, @Icons.Material.Filled.ChatBubble, @Icons.Material.Filled.CheckCircleOutline, @Icons.Material.Filled.Cloud,
                @Icons.Material.Filled.Code, @Icons.Material.Filled.Computer, @Icons.Material.Filled.ContentPaste, @Icons.Material.Filled.Copyright,
                @Icons.Material.Filled.CrueltyFree, @Icons.Material.Filled.DarkMode, @Icons.Material.Filled.DeviceHub
            };
        }
    }
}
