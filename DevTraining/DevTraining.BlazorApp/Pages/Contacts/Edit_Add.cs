using DevTraining.BlazorServer.Contacts.Services;
using DevTraining.BlazorServer.Contacts.Entities;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace DevTraining.BlazorServer.Pages.Contacts
{
    public partial class Edit_Add
    {
        [Inject]
        public IContactService ContactService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public Guid ContactId { get; set; }
        public string StatusClass { get; set; }
        public string Message { get; set; }
        public bool Saved { get; set; }
        public ContactResponseDTO Contact { get; set; } = new ContactResponseDTO();


        protected async override Task OnInitializedAsync()
        {
            if(ContactId != Guid.Empty)
                Contact = await ContactService.Get(ContactId);
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;
            if (ContactId == Guid.Empty)
            {
                var addedContact = await ContactService.Create(Contact);

                if (addedContact == null)
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
                else
                {
                    StatusClass = "alert-success";
                    Message = "New contact added successfully.";
                    Saved = true;
                }
            }
            else
            {
                await ContactService.Edit(Contact);
                StatusClass = "alert-success";
                Message = "Contact updated successfully.";
                Saved = true;
            }
        }
        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validtation errors. Please try again.";
        }
        protected async Task DeleteContact()
        {
            await ContactService.Delete(ContactId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }
        protected void NavigateToOverview()
        {
            NavigationManager.NavigateTo("contact-list");
        }
    }
}
