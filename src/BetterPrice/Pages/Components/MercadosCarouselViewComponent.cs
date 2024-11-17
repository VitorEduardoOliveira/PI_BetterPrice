using BetterPrice.Data.Repository;
using BetterPrice.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BetterPrice.Pages.Components;

public class MercadosCarouselViewComponent : ViewComponent
{
    private readonly MercadoRepository _repository;

    

    public MercadosCarouselViewComponent(MercadoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var mercados = (await _repository.CarregarDestaques())
            .Select((mercado, index) => new { mercado, index })
            .GroupBy(x => x.index / 3)
            .Select(g => g.Select(x => x.mercado).ToList())
            .ToList();

        return View(mercados);
    }
}