using Excercice_17_Maskinpark.Core.Entities;
using Excercice_17_Maskinpark.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.App.Component.EditTheMachine
{
    public partial class MachineNameEdit : ComponentBase
    {
        private string StatusClass = string.Empty;
        private string Message = string.Empty;
        protected bool ShowNameEditDialog { get; set; }
        [Parameter]
        public EventCallback<bool> ConfirmationNameChanged { get; set; }
        public Machine Machine { get; set; } = new();
        public string MachineId { get; set; }
        [Inject]
        public IMachineDataService MachineDataService { get; set; }

        internal void Show(Machine machine)
        {
            ShowNameEditDialog = true;
            Machine = machine;
            MachineId = machine.Id.ToString();
        }

        protected async Task CloseDialog(bool value)
        {
            ShowNameEditDialog = false;
            await ConfirmationNameChanged.InvokeAsync(value);
        }

        protected async Task HandleValidSubmit()
        {
            await MachineDataService.UpdateMachine(MachineId, Machine);
            StatusClass = "alert-success";
            Message = "Machine updated sucessfully";
            ShowNameEditDialog = false;
        }
        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation erros. Please try again!";
        }
    }
}
