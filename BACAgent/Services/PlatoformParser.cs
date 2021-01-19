using BACAgent.Models.Context;
using BACAgent.Models.DBTable;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BACAgent.Services
{
    public class PlatoformParser
    {
        public async void AddToDB(ApplicationDbContext context, int documentId, string inputName, object inputValue)
        {
            DocumentInput docInput = await context.DocumentInputs.FirstOrDefaultAsync(x => x.DocumentId == documentId && x.Name == inputName);

            if (docInput != null)
            {
                docInput = new DocumentInput
                {
                    Name = inputName,
                    InputTypeId = 3,
                    DocumentId = documentId,
                    CreateBy = "admin",
                    CreateDate = DateTime.UtcNow,
                    ModifyBy = "admin",
                    ModifyDate = DateTime.UtcNow
                };

                context.DocumentInputs.Add(docInput);
                await context.SaveChangesAsync();
            }

            ContractXDocumentInput contractXDocumentInput = new ContractXDocumentInput
            {
                ContractXDocumentId = 3,
                DocumentInputId = docInput.DocumentInputId,
                Value = inputValue.ToString(),
                CreateBy = "admin",
                CreateDate = DateTime.UtcNow,
                ModifyBy = "admin",
                ModifyDate = DateTime.UtcNow
            };
            
            await context.SaveChangesAsync();
        }
    }
}