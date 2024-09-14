using Domain.Combos.Parameters;

namespace Domain.Combos;

public sealed class Combo
{
    private Guid _id = Guid.NewGuid();
    private string _title = default!;
    
    private Combo()
    {
    }

    public Combo(CreateComboParameters parameters)
    {
       SetTitle(new SetComboTitleParameters
       {
           Title = parameters.Title
       });
    }

    public void SetTitle(SetComboTitleParameters parameters)
    {
        _title = parameters.Title;
    }
}