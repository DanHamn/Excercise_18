using Excercice_17_Maskinpark.Core.Entities;
using Excercice_17_Maskinpark.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.App.Component.EditTheMachine
{
    public partial class MachineEdit
    {
        private bool Saved;
        private string StatusClass = string.Empty;
        private string Message = string.Empty;

        protected bool ShowEdit { get; set; }
        [Inject]
        public IMachineDataService MachineDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string MachineId { get; set; }

        public Machine Machine { get; set; } = new();

        protected override async Task OnInitializedAsync()
        {
            Saved = false;

            if (string.IsNullOrEmpty(MachineId))
            {
                Machine = new Machine { Name = "", OnlineStatus = false, Data = "Added to the Machine Park" };
            }
            else
            {
                Machine = await MachineDataService.GetMachine(Guid.Parse(MachineId));
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            if (string.IsNullOrEmpty(MachineId))
            {
                var addedMachine = await MachineDataService.AddMachine(Machine);
                if (addedMachine != null)
                {
                    StatusClass = "alert-success";
                    Message = "New machine added sucessfully";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new machine. Please try again!";
                    Saved = true;
                }
            }
            else
            {

                await MachineDataService.UpdateMachine(MachineId, Machine);
                StatusClass = "alert-success";
                Message = "Machine updated sucessfully";
                Saved = true;
            }
        }
        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation erros. Please try again!";
        }

        protected void NavigateToMachinePark()
        {
            NavigationManager.NavigateTo("/machinepark");
        }

        protected void RefreshPage()
        {
            if (string.IsNullOrEmpty(MachineId))
            {
                NavigationManager.NavigateTo("/machineedit", forceLoad: true);

            }
            else
            {
                NavigationManager.NavigateTo($"/machineedit/{MachineId}", forceLoad: true);

            }
        }
    }
}