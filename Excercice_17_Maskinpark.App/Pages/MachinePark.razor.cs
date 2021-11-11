using Excercice_17_Maskinpark.App.Component;
using Excercice_17_Maskinpark.App.Component.Confirm;
using Excercice_17_Maskinpark.App.Component.EditTheMachine;
using Excercice_17_Maskinpark.Core.Entities;
using Excercice_17_Maskinpark.Core.Models;
using Excercice_17_Maskinpark.Core.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercice_17_Maskinpark.App.Pages
{
    public partial class MachinePark
    {
        private Machine machineToBeRemoved;

        protected GiveCommandDialog GiveCommandDialog { get; set; }
        protected ConfirmBase DeleteConfirmation { get; set; }
        protected MachineNameEdit EditNameDialog { get; set; }
        public MachineList Machines { get; private set; } = new();

        [Inject]
        public IMachineDataService MachineDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Machines = new MachineList()
            {
                ListOfMachines = (await MachineDataService.GetAllMachines()).ToList()
            };
        }

        protected async Task SwitchOnOffAsync(Machine machine)
        {
            machine.OnlineStatus = !machine.OnlineStatus;

            if (machine.OnlineStatus)
            {
                machine.Data = "Turned on";
            }
            else
            {
                machine.Data = "Turned off";
            }
            await MachineDataService.UpdateMachine(machine.Id.ToString(),machine);
            StateHasChanged();
        }

        protected void Remove_Click(Machine machine)
        {
            machineToBeRemoved = machine;
            DeleteConfirmation.Show();
        }

        private async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                var id = machineToBeRemoved.Id;
                machineToBeRemoved = null;
                await MachineDataService.DeleteMachine(id);
                StateHasChanged();
                NavigationManager.NavigateTo("/machinepark", forceLoad: true);
            }
        }

        protected void EditName_Click(Machine machine)
        {
            EditNameDialog.Show(machine);
        }
    }
}
