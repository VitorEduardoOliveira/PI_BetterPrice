using BetterPrice.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BetterPrice.Data;

public static class DadosPadroes
{
    public static void CategoriasPadroes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>().HasData(
            // Categorias do departamento de Alimentos
            new Categoria { Id = 1, Nome = "Grãos" },
            new Categoria { Id = 2, Nome = "Massas" },
            new Categoria { Id = 3, Nome = "Óleos e Temperos" },
            new Categoria { Id = 4, Nome = "Doces e Sobremesas" },

            // Categorias do departamento de Bebidas
            new Categoria { Id = 5, Nome = "Refrigerantes" },
            new Categoria { Id = 6, Nome = "Sucos" },
            new Categoria { Id = 7, Nome = "Águas e Isotônicos" },

            // Categorias do departamento de Higiene Pessoal
            new Categoria { Id = 8, Nome = "Shampoos e Condicionadores" },
            new Categoria { Id = 9, Nome = "Sabonetes e Gel para Banho" },
            new Categoria { Id = 10, Nome = "Escovas e Cremes Dentais" },

            // Categorias do departamento de Limpeza
            new Categoria { Id = 11, Nome = "Detergentes" },
            new Categoria { Id = 12, Nome = "Desinfetantes" },
            new Categoria { Id = 13, Nome = "Esponjas e Panos de Limpeza" });
    }

    public static void DepartamentosPadroes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>().HasData(
            new Departamento { Id = 1, Nome = "Alimentos" },
            new Departamento { Id = 2, Nome = "Bebidas" },
            new Departamento { Id = 3, Nome = "Limpeza" },
            new Departamento { Id = 4, Nome = "Higiene Pessoal" },
            new Departamento { Id = 5, Nome = "Frios" },
            new Departamento { Id = 6, Nome = "Congelados" },
            new Departamento { Id = 7, Nome = "Padaria" },
            new Departamento { Id = 8, Nome = "Frutas e Verduras" },
            new Departamento { Id = 9, Nome = "Carnes" },
            new Departamento { Id = 10, Nome = "Mercearia" }
        );
    }

    public static void ProdutosPadroes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().HasData(
            // Produtos do departamento de Alimentos, categoria Grãos
            new Produto { Id = 1, Nome = "Arroz Integral", Descricao = "Arroz integral de 5kg.", EAN = "7891234560011", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 1 },
            new Produto { Id = 2, Nome = "Feijão Preto", Descricao = "Feijão preto de 1kg.", EAN = "7891234560022", UrlImagem = "https://propao.agilecdn.com.br/4493_1.jpg", DepartamentoId = 1, CategoriaId = 1 },
            new Produto { Id = 3, Nome = "Macarrão Instantâneo", Descricao = "Macarrão instantâneo de 80g.", EAN = "7891234560033", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 2 },
            new Produto { Id = 4, Nome = "Óleo de Soja", Descricao = "Óleo de soja 900ml.", EAN = "7891234560044", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 3 },
            new Produto { Id = 5, Nome = "Chocolate ao Leite", Descricao = "Chocolate ao leite 200g.", EAN = "7891234560055", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 4 },

            // Produtos do departamento de Bebidas, categoria Refrigerantes
            new Produto { Id = 6, Nome = "Refrigerante de Cola", Descricao = "Refrigerante de cola 2L.", EAN = "7891234560066", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 2, CategoriaId = 5 },
            new Produto { Id = 7, Nome = "Refrigerante de Laranja", Descricao = "Refrigerante de laranja 2L.", EAN = "7891234560077", UrlImagem = "https://coopsp.vtexassets.com/arquivos/ids/215362-800-auto?v=637919527220430000&width=800&height=auto&aspect=true", DepartamentoId = 2, CategoriaId = 5 },
            new Produto { Id = 8, Nome = "Suco de Uva", Descricao = "Suco de uva integral 1L.", EAN = "7891234560088", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 2, CategoriaId = 6 },
            new Produto { Id = 9, Nome = "Suco de Laranja", Descricao = "Suco de laranja natural 1L.", EAN = "7891234560099", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 2, CategoriaId = 6 },
            new Produto { Id = 10, Nome = "Água Mineral", Descricao = "Água mineral 500ml.", EAN = "7891234560100", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 2, CategoriaId = 7 },

            // Produtos do departamento de Higiene Pessoal, categoria Shampoos
            new Produto { Id = 11, Nome = "Shampoo Anticaspa", Descricao = "Shampoo anticaspa 200ml.", EAN = "7891234560111", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 8 },
            new Produto { Id = 12, Nome = "Shampoo Hidratante", Descricao = "Shampoo hidratante 200ml.", EAN = "7891234560122", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 8 },
            new Produto { Id = 13, Nome = "Condicionador Fortalecedor", Descricao = "Condicionador fortalecedor 200ml.", EAN = "7891234560133", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 8 },
            new Produto { Id = 14, Nome = "Sabonete Líquido", Descricao = "Sabonete líquido 250ml.", EAN = "7891234560144", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 9 },
            new Produto { Id = 15, Nome = "Escova Dental", Descricao = "Escova dental macia.", EAN = "7891234560155", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 10 },

            // Produtos do departamento de Limpeza, categoria Detergentes
            new Produto { Id = 16, Nome = "Detergente Neutro", Descricao = "Detergente neutro 500ml.", EAN = "7891234560166", UrlImagem = "https://tb0932.vtexassets.com/arquivos/ids/162732-800-auto?v=637705337202370000&width=800&height=auto&aspect=true", DepartamentoId = 4, CategoriaId = 11 },
            new Produto { Id = 17, Nome = "Detergente de Coco", Descricao = "Detergente de coco 500ml.", EAN = "7891234560177", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 4, CategoriaId = 11 },
            new Produto { Id = 18, Nome = "Desinfetante Floral", Descricao = "Desinfetante floral 500ml.", EAN = "7891234560188", UrlImagem = "https://images.tcdn.com.br/img/img_prod/1213476/desinfetante_5_litros_guimaraes_floral_2655_1_ef004baff3bc763e9629435d6a8b1c0c.jpg", DepartamentoId = 4, CategoriaId = 12 },
            new Produto { Id = 19, Nome = "Desinfetante Limão", Descricao = "Desinfetante de limão 500ml.", EAN = "7891234560199", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 4, CategoriaId = 12 },
            new Produto { Id = 20, Nome = "Esponja de Aço", Descricao = "Esponja de aço 3 unidades.", EAN = "7891234560200", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 4, CategoriaId = 13 },

            // Produtos adicionais para outros departamentos e categorias
            new Produto { Id = 21, Nome = "Arroz Parboilizado", Descricao = "Arroz parboilizado 5kg.", EAN = "7891234560211", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 1 },
            new Produto { Id = 22, Nome = "Macarrão Espaguete", Descricao = "Macarrão espaguete 500g.", EAN = "7891234560222", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 2 },
            new Produto { Id = 23, Nome = "Molho de Tomate", Descricao = "Molho de tomate 340g.", EAN = "7891234560233", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 3 },
            new Produto { Id = 24, Nome = "Biscoito Recheado", Descricao = "Biscoito recheado 150g.", EAN = "7891234560244", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 4 },
            new Produto { Id = 25, Nome = "Suco de Abacaxi", Descricao = "Suco de abacaxi 1L.", EAN = "7891234560255", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 2, CategoriaId = 6 },

                        
            new Produto { Id = 26, Nome = "Biscoito Salgado", Descricao = "Biscoito salgado 200g.", EAN = "7891234560266", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 4 },
            new Produto { Id = 27, Nome = "Queijo Prato", Descricao = "Queijo prato fatiado 300g.", EAN = "7891234560277", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 5, CategoriaId = 5 },
            new Produto { Id = 28, Nome = "Presunto", Descricao = "Presunto fatiado 300g.", EAN = "7891234560288", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 5, CategoriaId = 5 },
            new Produto { Id = 29, Nome = "Mortadela", Descricao = "Mortadela fatiada 300g.", EAN = "7891234560299", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 5, CategoriaId = 5 },
            new Produto { Id = 30, Nome = "Leite Condensado", Descricao = "Leite condensado 395g.", EAN = "7891234560300", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 4 },

            // Produtos do departamento de Higiene Pessoal, categoria Sabonetes
            new Produto { Id = 31, Nome = "Sabonete em Barra", Descricao = "Sabonete em barra 90g.", EAN = "7891234560311", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 9 },
            new Produto { Id = 32, Nome = "Sabonete de Coco", Descricao = "Sabonete de coco 90g.", EAN = "7891234560322", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 9 },
            new Produto { Id = 33, Nome = "Desodorante Aerosol", Descricao = "Desodorante aerosol 150ml.", EAN = "7891234560333", UrlImagem = "https://example.com/desodorante_aerosol.jpg", DepartamentoId = 3, CategoriaId = 10 },
            new Produto { Id = 34, Nome = "Pasta de Dente", Descricao = "Pasta de dente 90g.", EAN = "7891234560344", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 10 },

            // Produtos do departamento de Limpeza, categoria Amaciantes
            new Produto { Id = 35, Nome = "Amaciante Floral", Descricao = "Amaciante floral 1L.", EAN = "7891234560355", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 4, CategoriaId = 12 },
            new Produto { Id = 36, Nome = "Amaciante Limão", Descricao = "Amaciante de limão 1L.", EAN = "7891234560366", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 4, CategoriaId = 12 },

            // Produtos do departamento de Higiene Pessoal, categoria Cabelos
            new Produto { Id = 37, Nome = "Creme para Pentear", Descricao = "Creme para pentear 300ml.", EAN = "7891234560377", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 8 },
            new Produto { Id = 38, Nome = "Óleo Capilar", Descricao = "Óleo capilar 100ml.", EAN = "7891234560388", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 3, CategoriaId = 8 },

            // Produtos do departamento de Alimentos, categoria Laticínios
            new Produto { Id = 39, Nome = "Manteiga", Descricao = "Manteiga 200g.", EAN = "7891234560399", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 5 },
            new Produto { Id = 40, Nome = "Iogurte Natural", Descricao = "Iogurte natural 400g.", EAN = "7891234560400", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 5 },

            // Produtos do departamento de Bebidas, categoria Águas
            new Produto { Id = 41, Nome = "Água com Gás", Descricao = "Água com gás 500ml.", EAN = "7891234560411", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 2, CategoriaId = 7 },
            new Produto { Id = 42, Nome = "Água com Limão", Descricao = "Água com limão 500ml.", EAN = "7891234560422", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 2, CategoriaId = 7 },

            // Produtos do departamento de Limpeza, categoria Limpeza Pesada
            new Produto { Id = 43, Nome = "Desinfetante Sanitário", Descricao = "Desinfetante sanitário 500ml.", EAN = "7891234560433", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 4, CategoriaId = 12 },
            new Produto { Id = 44, Nome = "Desengordurante", Descricao = "Desengordurante 500ml.", EAN = "7891234560444", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 4, CategoriaId = 13 },

            // Produtos adicionais
            new Produto { Id = 45, Nome = "Margarina", Descricao = "Margarina 500g.", EAN = "7891234560455", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 5 },
            new Produto { Id = 46, Nome = "Chocolate em Pó", Descricao = "Chocolate em pó 400g.", EAN = "7891234560466", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 4 },
            new Produto { Id = 47, Nome = "Bolacha Cream Cracker", Descricao = "Bolacha cream cracker 200g.", EAN = "7891234560477", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 4 },
            new Produto { Id = 48, Nome = "Pão de Forma", Descricao = "Pão de forma 500g.", EAN = "7891234560488", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 1, CategoriaId = 3 },
            new Produto { Id = 49, Nome = "Queijo Mussarela", Descricao = "Queijo mussarela fatiado 300g.", EAN = "7891234560499", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 5, CategoriaId = 5 },
            new Produto { Id = 50, Nome = "Suco de Caju", Descricao = "Suco de caju 1L.", EAN = "7891234560500", UrlImagem = "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif", DepartamentoId = 2, CategoriaId = 6 }
        );
    }

    public static void PrecosPadroes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemPreco>().HasData(
            new ItemPreco { Id = 1, ProdutoId = 1, MercadoId = 1, Valor = 12.99m, Oferta = 10.99m, Destaque = false },
            new ItemPreco { Id = 2, ProdutoId = 2, MercadoId = 2, Valor = 8.50m, Oferta = 7.90m, Destaque = false },
            new ItemPreco { Id = 3, ProdutoId = 3, MercadoId = 3, Valor = 3.40m, Oferta = 2.90m, Destaque = false },
            new ItemPreco { Id = 4, ProdutoId = 4, MercadoId = 4, Valor = 7.80m, Oferta = 6.50m, Destaque = true },
            new ItemPreco { Id = 5, ProdutoId = 5, MercadoId = 5, Valor = 5.60m, Oferta = 4.99m, Destaque = false },
            new ItemPreco { Id = 6, ProdutoId = 6, MercadoId = 6, Valor = 6.99m, Oferta = 5.99m, Destaque = false },
            new ItemPreco { Id = 7, ProdutoId = 7, MercadoId = 7, Valor = 9.90m, Oferta = 8.50m, Destaque = false },
            new ItemPreco { Id = 8, ProdutoId = 8, MercadoId = 8, Valor = 3.50m, Oferta = 2.99m, Destaque = false },
            new ItemPreco { Id = 9, ProdutoId = 9, MercadoId = 9, Valor = 2.30m, Oferta = 1.99m, Destaque = false },
            new ItemPreco { Id = 10, ProdutoId = 10, MercadoId = 10, Valor = 1.99m, Oferta = 1.69m, Destaque = false },
            new ItemPreco { Id = 11, ProdutoId = 11, MercadoId = 1, Valor = 15.00m, Oferta = 12.50m, Destaque = false },
            new ItemPreco { Id = 12, ProdutoId = 12, MercadoId = 2, Valor = 12.00m, Oferta = 10.00m, Destaque = false },
            new ItemPreco { Id = 13, ProdutoId = 13, MercadoId = 3, Valor = 18.00m, Oferta = 16.00m, Destaque = false },
            new ItemPreco { Id = 14, ProdutoId = 14, MercadoId = 4, Valor = 4.50m, Oferta = 3.99m, Destaque = false },
            new ItemPreco { Id = 15, ProdutoId = 15, MercadoId = 5, Valor = 5.99m, Oferta = 4.99m, Destaque = false },
            new ItemPreco { Id = 16, ProdutoId = 16, MercadoId = 6, Valor = 7.50m, Oferta = 6.00m, Destaque = true },
            new ItemPreco { Id = 17, ProdutoId = 17, MercadoId = 7, Valor = 4.90m, Oferta = 4.50m, Destaque = false },
            new ItemPreco { Id = 18, ProdutoId = 18, MercadoId = 8, Valor = 6.20m, Oferta = 5.50m, Destaque = false },
            new ItemPreco { Id = 19, ProdutoId = 19, MercadoId = 9, Valor = 7.80m, Oferta = 6.70m, Destaque = false },
            new ItemPreco { Id = 20, ProdutoId = 20, MercadoId = 10, Valor = 10.00m, Oferta = 8.99m, Destaque = false },

            new ItemPreco { Id = 21, ProdutoId = 1, MercadoId = 2, Valor = 13.50m, Oferta = 11.00m, Destaque = false },
            new ItemPreco { Id = 22, ProdutoId = 2, MercadoId = 3, Valor = 9.00m, Oferta = 7.50m, Destaque = true },
            new ItemPreco { Id = 23, ProdutoId = 3, MercadoId = 4, Valor = 3.80m, Oferta = 3.20m, Destaque = false },
            new ItemPreco { Id = 24, ProdutoId = 4, MercadoId = 5, Valor = 8.30m, Oferta = 7.10m, Destaque = false },
            new ItemPreco { Id = 25, ProdutoId = 5, MercadoId = 6, Valor = 6.50m, Oferta = 5.20m, Destaque = false },
            new ItemPreco { Id = 26, ProdutoId = 6, MercadoId = 7, Valor = 7.20m, Oferta = 6.00m, Destaque = false },
            new ItemPreco { Id = 27, ProdutoId = 7, MercadoId = 8, Valor = 10.10m, Oferta = 8.90m, Destaque = false },
            new ItemPreco { Id = 28, ProdutoId = 8, MercadoId = 9, Valor = 4.10m, Oferta = 3.50m, Destaque = false },
            new ItemPreco { Id = 29, ProdutoId = 9, MercadoId = 10, Valor = 2.50m, Oferta = 2.10m, Destaque = false },
            new ItemPreco { Id = 30, ProdutoId = 10, MercadoId = 1, Valor = 1.90m, Oferta = 1.60m, Destaque = false },

            new ItemPreco { Id = 31, ProdutoId = 11, MercadoId = 2, Valor = 16.50m, Oferta = 14.00m, Destaque = false },
            new ItemPreco { Id = 32, ProdutoId = 12, MercadoId = 3, Valor = 13.20m, Oferta = 11.80m, Destaque = false },
            new ItemPreco { Id = 33, ProdutoId = 13, MercadoId = 4, Valor = 19.50m, Oferta = 17.00m, Destaque = false },
            new ItemPreco { Id = 37, ProdutoId = 17, MercadoId = 8, Valor = 5.00m, Oferta = 4.30m, Destaque = false },
            new ItemPreco { Id = 38, ProdutoId = 18, MercadoId = 9, Valor = 6.50m, Oferta = 5.90m, Destaque = false },
            new ItemPreco { Id = 39, ProdutoId = 19, MercadoId = 10, Valor = 8.00m, Oferta = 6.50m, Destaque = false },
            new ItemPreco { Id = 40, ProdutoId = 20, MercadoId = 1, Valor = 10.50m, Oferta = 9.20m, Destaque = false },

            new ItemPreco { Id = 41, ProdutoId = 1, MercadoId = 9, Valor = 14.00m, Oferta = 12.50m, Destaque = false },
            new ItemPreco { Id = 42, ProdutoId = 2, MercadoId = 8, Valor = 9.50m, Oferta = 8.00m, Destaque = false },
            new ItemPreco { Id = 44, ProdutoId = 4, MercadoId = 6, Valor = 8.00m, Oferta = 6.50m, Destaque = false },
            new ItemPreco { Id = 49, ProdutoId = 9, MercadoId = 1, Valor = 2.80m, Oferta = 2.50m, Destaque = false },
            new ItemPreco { Id = 50, ProdutoId = 10, MercadoId = 10, Valor = 2.20m, Oferta = 2.00m, Destaque = false },

            new ItemPreco { Id = 51, ProdutoId = 19, MercadoId = 1, Valor = 8.50m, Oferta = 7.50m, Destaque = false },
            new ItemPreco { Id = 52, ProdutoId = 12, MercadoId = 2, Valor = 13.90m, Oferta = 12.00m, Destaque = false },
            new ItemPreco { Id = 53, ProdutoId = 5, MercadoId = 3, Valor = 6.20m, Oferta = 5.70m, Destaque = false },
            new ItemPreco { Id = 54, ProdutoId = 7, MercadoId = 4, Valor = 10.00m, Oferta = 8.50m, Destaque = true },
            new ItemPreco { Id = 55, ProdutoId = 1, MercadoId = 5, Valor = 12.30m, Oferta = 10.90m, Destaque = false },
            new ItemPreco { Id = 56, ProdutoId = 10, MercadoId = 6, Valor = 2.10m, Oferta = 1.80m, Destaque = false },
            new ItemPreco { Id = 57, ProdutoId = 16, MercadoId = 7, Valor = 7.60m, Oferta = 6.80m, Destaque = true },
            new ItemPreco { Id = 59, ProdutoId = 8, MercadoId = 9, Valor = 4.00m, Oferta = 3.50m, Destaque = false },
            new ItemPreco { Id = 60, ProdutoId = 9, MercadoId = 10, Valor = 2.50m, Oferta = 2.10m, Destaque = false },

            new ItemPreco { Id = 61, ProdutoId = 4, MercadoId = 1, Valor = 7.90m, Oferta = 6.60m, Destaque = false },
            new ItemPreco { Id = 62, ProdutoId = 11, MercadoId = 2, Valor = 15.10m, Oferta = 13.00m, Destaque = false },
            new ItemPreco { Id = 63, ProdutoId = 3, MercadoId = 3, Valor = 3.90m, Oferta = 3.30m, Destaque = false },
            new ItemPreco { Id = 64, ProdutoId = 14, MercadoId = 4, Valor = 4.50m, Oferta = 3.80m, Destaque = false },
            new ItemPreco { Id = 69, ProdutoId = 6, MercadoId = 9, Valor = 7.30m, Oferta = 6.50m, Destaque = false },
            new ItemPreco { Id = 70, ProdutoId = 18, MercadoId = 10, Valor = 6.80m, Oferta = 6.00m, Destaque = false },

            new ItemPreco { Id = 72, ProdutoId = 12, MercadoId = 6, Valor = 14.80m, Oferta = 13.20m, Destaque = false },
            new ItemPreco { Id = 73, ProdutoId = 10, MercadoId = 7, Valor = 2.30m, Oferta = 2.10m, Destaque = false },
            new ItemPreco { Id = 74, ProdutoId = 7, MercadoId = 8, Valor = 9.90m, Oferta = 8.60m, Destaque = false },
            new ItemPreco { Id = 75, ProdutoId = 5, MercadoId = 9, Valor = 6.00m, Oferta = 5.20m, Destaque = false },
            new ItemPreco { Id = 76, ProdutoId = 8, MercadoId = 10, Valor = 3.80m, Oferta = 3.30m, Destaque = false },
            new ItemPreco { Id = 78, ProdutoId = 9, MercadoId = 2, Valor = 2.20m, Oferta = 2.00m, Destaque = false },
            new ItemPreco { Id = 79, ProdutoId = 16, MercadoId = 3, Valor = 7.90m, Oferta = 7.10m, Destaque = false },

            new ItemPreco { Id = 81, ProdutoId = 13, MercadoId = 5, Valor = 18.50m, Oferta = 16.00m, Destaque = false },
            new ItemPreco { Id = 82, ProdutoId = 3, MercadoId = 6, Valor = 4.20m, Oferta = 3.80m, Destaque = false },
            new ItemPreco { Id = 83, ProdutoId = 15, MercadoId = 7, Valor = 6.50m, Oferta = 5.80m, Destaque = false },
            new ItemPreco { Id = 89, ProdutoId = 6, MercadoId = 4, Valor = 7.10m, Oferta = 6.60m, Destaque = false },
            new ItemPreco { Id = 90, ProdutoId = 14, MercadoId = 5, Valor = 4.80m, Oferta = 4.20m, Destaque = false },

            new ItemPreco { Id = 91, ProdutoId = 8, MercadoId = 6, Valor = 3.90m, Oferta = 3.30m, Destaque = false },
            new ItemPreco { Id = 92, ProdutoId = 4, MercadoId = 7, Valor = 8.10m, Oferta = 7.00m, Destaque = false },
            new ItemPreco { Id = 93, ProdutoId = 2, MercadoId = 8, Valor = 7.90m, Oferta = 7.10m, Destaque = false },
            new ItemPreco { Id = 94, ProdutoId = 12, MercadoId = 9, Valor = 15.00m, Oferta = 13.50m, Destaque = false },
            new ItemPreco { Id = 95, ProdutoId = 5, MercadoId = 10, Valor = 5.70m, Oferta = 5.10m, Destaque = false },

            new ItemPreco { Id = 96, ProdutoId = 10, MercadoId = 2, Valor = 2.00m, Oferta = 1.80m, Destaque = false },
            new ItemPreco { Id = 97, ProdutoId = 15, MercadoId = 3, Valor = 6.00m, Oferta = 5.50m, Destaque = false },
            new ItemPreco { Id = 98, ProdutoId = 7, MercadoId = 4, Valor = 9.50m, Oferta = 8.00m, Destaque = true },
            new ItemPreco { Id = 99, ProdutoId = 13, MercadoId = 5, Valor = 17.90m, Oferta = 16.40m, Destaque = false },
            new ItemPreco { Id = 100, ProdutoId = 18, MercadoId = 6, Valor = 6.80m, Oferta = 6.20m, Destaque = false }
            );
    }

    public static void MercadosPadroes(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Mercado>().HasData(
            new Mercado { Id = 1, Nome = "Pão de Açúcar", Endereco = "Rua das Palmeiras, 123, São Paulo, SP", UrlImagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcTl6OrE1EUtntSDrM_xGQ_i79qJdq5dBq9g&s", Destaque = true },
            new Mercado { Id = 2, Nome = "Carrefour", Endereco = "Avenida Paulista, 500, São Paulo, SP", UrlImagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTF7y3UbeRtSKAlHHy5W0p-hejaCi9KihHCkA&s", Destaque = true },
            new Mercado { Id = 3, Nome = "Extra", Endereco = "Rua 25 de Março, 1010, São Paulo, SP", UrlImagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOf-t-njVAeC0v0M2Xy5e4Kn9QND636ytb9A&s", Destaque = true },
            new Mercado { Id = 5, Nome = "Atacadão Spani", Endereco = "Avenida do Estado, 9876, São Paulo, SP", UrlImagem = "https://example.com/atacadao.jpg", Destaque = false },
            new Mercado { Id = 7, Nome = "Hipermercado Walmart", Endereco = "Rua do Sabor, 3456, São Paulo, SP", UrlImagem = "https://pbs.twimg.com/profile_images/1539351712514842629/Mvtw8vAt_400x400.png", Destaque = true },
            new Mercado { Id = 8, Nome = "Roldão", Endereco = "Avenida dos Três, 1234, São Paulo, SP", UrlImagem = "https://example.com/roldao.jpg", Destaque = false },
            new Mercado { Id = 9, Nome = "Tesco", Endereco = "Rua do Mercado, 4321, São Paulo, SP", UrlImagem = "https://example.com/tesco.jpg", Destaque = false },
            new Mercado { Id = 10, Nome = "Sonae", Endereco = "Avenida Principal, 6789, São Paulo, SP", UrlImagem = "https://example.com/sonae.jpg", Destaque = false },
            new Mercado { Id = 4, Nome = "Covabra", Endereco = "Avenida São João, 101, Campinas, SP", UrlImagem = "https://yt3.googleusercontent.com/WxxBjaJlFVe0-OiEbxrcQLCw1hiWKN4IosKxooYkKSKN1dhPvvGDk44MwoYJBo87cJpc7UDa3w=s900-c-k-c0x00ffffff-no-rj", Destaque = true },
            new Mercado { Id = 6, Nome = "Savenago", Endereco = "Rua Rio Branco, 777, São João da Boa Vista, SP", UrlImagem = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCD1GIZZBPrq5vkGYaZwhD7E-iam-NeANTzw&s", Destaque = true }
        );
    }
}    