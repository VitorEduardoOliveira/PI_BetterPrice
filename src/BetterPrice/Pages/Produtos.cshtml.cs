using BetterPrice.Data.Repository;
using BetterPrice.Entities;
using BetterPrice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BetterPrice.Pages;

public class ProdutosModel : PageModel
{
    private readonly CategoriaRepository _categoriasRepository;
    private readonly DepartamentoRepository _departamentosRepository;
    private readonly ItemRepository _itemRepository;

    [BindProperty(SupportsGet = true)]
    public FiltroProduto Filtro { get; set; } = new();

    public List<Categoria> Categorias { get; set; }

    [BindProperty]
    public List<int> CategoriasSelecionadas { get; set; }

    public List<Departamento> Departamentos { get; set; }

    [BindProperty]
    public List<int> DepartamentosSelecionados { get; set; }

    [BindProperty]
    public PrecoVM PrecoVM { get; set; }  

    public ProdutosModel(CategoriaRepository categoriasRepository, 
                         DepartamentoRepository departamentosRepository,
                         ItemRepository itemRepository)
    {
        _categoriasRepository = categoriasRepository;
        _departamentosRepository = departamentosRepository;
        _itemRepository = itemRepository;
    }

    
    public async Task OnGetAsync(FiltroProduto filtro)
    {
        Filtro = filtro;
        Categorias = await _categoriasRepository.ListarCategorias();
        Departamentos = await _departamentosRepository.ListarDepartamentos();
        PrecoVM = new();

        await _itemRepository.CarregarItems(Filtro);
    }

    public IActionResult OnPostPesquisaAsync()
    {
        Filtro.Categorias = CategoriasSelecionadas.Any()
            ? CategoriasSelecionadas.ToArray()
            : null;

        Filtro.Departamentos = DepartamentosSelecionados.Any()
            ? DepartamentosSelecionados.ToArray()
            : null;

        Filtro.OrdenarMaiorMenor = PrecoVM.OrdenarMaiorMenor;
        Filtro.OrdernarMenorMaior = PrecoVM.OrdernarMenorMaior;

        Filtro.Ate50 = PrecoVM.Ate50;
        Filtro.De50a200 = PrecoVM.De51a200;
        Filtro.Acima200 = PrecoVM.Acima200;

        return RedirectToPage("Produtos", Filtro);
    }
}