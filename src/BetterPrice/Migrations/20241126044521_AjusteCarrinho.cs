using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BetterPrice.Migrations
{
    /// <inheritdoc />
    public partial class AjusteCarrinho : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Endereco = table.Column<string>(type: "text", nullable: false),
                    UrlImagem = table.Column<string>(type: "text", nullable: false),
                    Destaque = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Senha = table.Column<string>(type: "text", nullable: true),
                    TipoAutenticacao = table.Column<int>(type: "integer", nullable: false),
                    CarrinhoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Descricao = table.Column<string>(type: "text", nullable: false),
                    EAN = table.Column<string>(type: "text", nullable: false),
                    UrlImagem = table.Column<string>(type: "text", nullable: false),
                    DepartamentoId = table.Column<int>(type: "integer", nullable: false),
                    CategoriaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produtos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UsuarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinhos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPrecos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdutoId = table.Column<int>(type: "integer", nullable: false),
                    MercadoId = table.Column<int>(type: "integer", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    Oferta = table.Column<decimal>(type: "numeric", nullable: false),
                    Destaque = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrecos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPrecos_Mercados_MercadoId",
                        column: x => x.MercadoId,
                        principalTable: "Mercados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemPrecos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemCarrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CarrinhoId = table.Column<int>(type: "integer", nullable: false),
                    ItemId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCarrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemCarrinhos_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCarrinhos_ItemPrecos_ItemId",
                        column: x => x.ItemId,
                        principalTable: "ItemPrecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Grãos" },
                    { 2, "Massas" },
                    { 3, "Óleos e Temperos" },
                    { 4, "Doces e Sobremesas" },
                    { 5, "Refrigerantes" },
                    { 6, "Sucos" },
                    { 7, "Águas e Isotônicos" },
                    { 8, "Shampoos e Condicionadores" },
                    { 9, "Sabonetes e Gel para Banho" },
                    { 10, "Escovas e Cremes Dentais" },
                    { 11, "Detergentes" },
                    { 12, "Desinfetantes" },
                    { 13, "Esponjas e Panos de Limpeza" }
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Alimentos" },
                    { 2, "Bebidas" },
                    { 3, "Limpeza" },
                    { 4, "Higiene Pessoal" },
                    { 5, "Frios" },
                    { 6, "Congelados" },
                    { 7, "Padaria" },
                    { 8, "Frutas e Verduras" },
                    { 9, "Carnes" },
                    { 10, "Mercearia" }
                });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "Id", "Destaque", "Endereco", "Nome", "UrlImagem" },
                values: new object[,]
                {
                    { 1, true, "Rua das Palmeiras, 123, São Paulo, SP", "Pão de Açúcar", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTcTl6OrE1EUtntSDrM_xGQ_i79qJdq5dBq9g&s" },
                    { 2, true, "Avenida Paulista, 500, São Paulo, SP", "Carrefour", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTF7y3UbeRtSKAlHHy5W0p-hejaCi9KihHCkA&s" },
                    { 3, true, "Rua 25 de Março, 1010, São Paulo, SP", "Extra", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQOf-t-njVAeC0v0M2Xy5e4Kn9QND636ytb9A&s" },
                    { 4, true, "Avenida São João, 101, Campinas, SP", "Covabra", "https://yt3.googleusercontent.com/WxxBjaJlFVe0-OiEbxrcQLCw1hiWKN4IosKxooYkKSKN1dhPvvGDk44MwoYJBo87cJpc7UDa3w=s900-c-k-c0x00ffffff-no-rj" },
                    { 5, false, "Avenida do Estado, 9876, São Paulo, SP", "Atacadão Spani", "https://example.com/atacadao.jpg" },
                    { 6, true, "Rua Rio Branco, 777, São João da Boa Vista, SP", "Savenago", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTCD1GIZZBPrq5vkGYaZwhD7E-iam-NeANTzw&s" },
                    { 7, true, "Rua do Sabor, 3456, São Paulo, SP", "Hipermercado Walmart", "https://pbs.twimg.com/profile_images/1539351712514842629/Mvtw8vAt_400x400.png" },
                    { 8, false, "Avenida dos Três, 1234, São Paulo, SP", "Roldão", "https://example.com/roldao.jpg" },
                    { 9, false, "Rua do Mercado, 4321, São Paulo, SP", "Tesco", "https://example.com/tesco.jpg" },
                    { 10, false, "Avenida Principal, 6789, São Paulo, SP", "Sonae", "https://example.com/sonae.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "DepartamentoId", "Descricao", "EAN", "Nome", "UrlImagem" },
                values: new object[,]
                {
                    { 1, 1, 1, "Arroz integral de 5kg.", "7891234560011", "Arroz Integral", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 2, 1, 1, "Feijão preto de 1kg.", "7891234560022", "Feijão Preto", "https://propao.agilecdn.com.br/4493_1.jpg" },
                    { 3, 2, 1, "Macarrão instantâneo de 80g.", "7891234560033", "Macarrão Instantâneo", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 4, 3, 1, "Óleo de soja 900ml.", "7891234560044", "Óleo de Soja", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 5, 4, 1, "Chocolate ao leite 200g.", "7891234560055", "Chocolate ao Leite", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 6, 5, 2, "Refrigerante de cola 2L.", "7891234560066", "Refrigerante de Cola", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 7, 5, 2, "Refrigerante de laranja 2L.", "7891234560077", "Refrigerante de Laranja", "https://coopsp.vtexassets.com/arquivos/ids/215362-800-auto?v=637919527220430000&width=800&height=auto&aspect=true" },
                    { 8, 6, 2, "Suco de uva integral 1L.", "7891234560088", "Suco de Uva", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 9, 6, 2, "Suco de laranja natural 1L.", "7891234560099", "Suco de Laranja", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 10, 7, 2, "Água mineral 500ml.", "7891234560100", "Água Mineral", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 11, 8, 3, "Shampoo anticaspa 200ml.", "7891234560111", "Shampoo Anticaspa", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 12, 8, 3, "Shampoo hidratante 200ml.", "7891234560122", "Shampoo Hidratante", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 13, 8, 3, "Condicionador fortalecedor 200ml.", "7891234560133", "Condicionador Fortalecedor", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 14, 9, 3, "Sabonete líquido 250ml.", "7891234560144", "Sabonete Líquido", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 15, 10, 3, "Escova dental macia.", "7891234560155", "Escova Dental", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 16, 11, 4, "Detergente neutro 500ml.", "7891234560166", "Detergente Neutro", "https://tb0932.vtexassets.com/arquivos/ids/162732-800-auto?v=637705337202370000&width=800&height=auto&aspect=true" },
                    { 17, 11, 4, "Detergente de coco 500ml.", "7891234560177", "Detergente de Coco", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 18, 12, 4, "Desinfetante floral 500ml.", "7891234560188", "Desinfetante Floral", "https://images.tcdn.com.br/img/img_prod/1213476/desinfetante_5_litros_guimaraes_floral_2655_1_ef004baff3bc763e9629435d6a8b1c0c.jpg" },
                    { 19, 12, 4, "Desinfetante de limão 500ml.", "7891234560199", "Desinfetante Limão", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 20, 13, 4, "Esponja de aço 3 unidades.", "7891234560200", "Esponja de Aço", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 21, 1, 1, "Arroz parboilizado 5kg.", "7891234560211", "Arroz Parboilizado", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 22, 2, 1, "Macarrão espaguete 500g.", "7891234560222", "Macarrão Espaguete", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 23, 3, 1, "Molho de tomate 340g.", "7891234560233", "Molho de Tomate", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 24, 4, 1, "Biscoito recheado 150g.", "7891234560244", "Biscoito Recheado", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 25, 6, 2, "Suco de abacaxi 1L.", "7891234560255", "Suco de Abacaxi", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 26, 4, 1, "Biscoito salgado 200g.", "7891234560266", "Biscoito Salgado", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 27, 5, 5, "Queijo prato fatiado 300g.", "7891234560277", "Queijo Prato", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 28, 5, 5, "Presunto fatiado 300g.", "7891234560288", "Presunto", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 29, 5, 5, "Mortadela fatiada 300g.", "7891234560299", "Mortadela", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 30, 4, 1, "Leite condensado 395g.", "7891234560300", "Leite Condensado", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 31, 9, 3, "Sabonete em barra 90g.", "7891234560311", "Sabonete em Barra", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 32, 9, 3, "Sabonete de coco 90g.", "7891234560322", "Sabonete de Coco", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 33, 10, 3, "Desodorante aerosol 150ml.", "7891234560333", "Desodorante Aerosol", "https://example.com/desodorante_aerosol.jpg" },
                    { 34, 10, 3, "Pasta de dente 90g.", "7891234560344", "Pasta de Dente", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 35, 12, 4, "Amaciante floral 1L.", "7891234560355", "Amaciante Floral", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 36, 12, 4, "Amaciante de limão 1L.", "7891234560366", "Amaciante Limão", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 37, 8, 3, "Creme para pentear 300ml.", "7891234560377", "Creme para Pentear", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 38, 8, 3, "Óleo capilar 100ml.", "7891234560388", "Óleo Capilar", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 39, 5, 1, "Manteiga 200g.", "7891234560399", "Manteiga", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 40, 5, 1, "Iogurte natural 400g.", "7891234560400", "Iogurte Natural", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 41, 7, 2, "Água com gás 500ml.", "7891234560411", "Água com Gás", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 42, 7, 2, "Água com limão 500ml.", "7891234560422", "Água com Limão", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 43, 12, 4, "Desinfetante sanitário 500ml.", "7891234560433", "Desinfetante Sanitário", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 44, 13, 4, "Desengordurante 500ml.", "7891234560444", "Desengordurante", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 45, 5, 1, "Margarina 500g.", "7891234560455", "Margarina", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 46, 4, 1, "Chocolate em pó 400g.", "7891234560466", "Chocolate em Pó", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 47, 4, 1, "Bolacha cream cracker 200g.", "7891234560477", "Bolacha Cream Cracker", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 48, 3, 1, "Pão de forma 500g.", "7891234560488", "Pão de Forma", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 49, 5, 5, "Queijo mussarela fatiado 300g.", "7891234560499", "Queijo Mussarela", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" },
                    { 50, 6, 2, "Suco de caju 1L.", "7891234560500", "Suco de Caju", "https://www.aquarelapapeis.com.br/arquivos/produto_sem_foto.gif" }
                });

            migrationBuilder.InsertData(
                table: "ItemPrecos",
                columns: new[] { "Id", "Destaque", "MercadoId", "Oferta", "ProdutoId", "Valor" },
                values: new object[,]
                {
                    { 1, false, 1, 10.99m, 1, 12.99m },
                    { 2, false, 2, 7.90m, 2, 8.50m },
                    { 3, false, 3, 2.90m, 3, 3.40m },
                    { 4, true, 4, 6.50m, 4, 7.80m },
                    { 5, false, 5, 4.99m, 5, 5.60m },
                    { 6, false, 6, 5.99m, 6, 6.99m },
                    { 7, false, 7, 8.50m, 7, 9.90m },
                    { 8, false, 8, 2.99m, 8, 3.50m },
                    { 9, false, 9, 1.99m, 9, 2.30m },
                    { 10, false, 10, 1.69m, 10, 1.99m },
                    { 11, false, 1, 12.50m, 11, 15.00m },
                    { 12, false, 2, 10.00m, 12, 12.00m },
                    { 13, false, 3, 16.00m, 13, 18.00m },
                    { 14, false, 4, 3.99m, 14, 4.50m },
                    { 15, false, 5, 4.99m, 15, 5.99m },
                    { 16, true, 6, 6.00m, 16, 7.50m },
                    { 17, false, 7, 4.50m, 17, 4.90m },
                    { 18, false, 8, 5.50m, 18, 6.20m },
                    { 19, false, 9, 6.70m, 19, 7.80m },
                    { 20, false, 10, 8.99m, 20, 10.00m },
                    { 21, false, 2, 11.00m, 1, 13.50m },
                    { 22, true, 3, 7.50m, 2, 9.00m },
                    { 23, false, 4, 3.20m, 3, 3.80m },
                    { 24, false, 5, 7.10m, 4, 8.30m },
                    { 25, false, 6, 5.20m, 5, 6.50m },
                    { 26, false, 7, 6.00m, 6, 7.20m },
                    { 27, false, 8, 8.90m, 7, 10.10m },
                    { 28, false, 9, 3.50m, 8, 4.10m },
                    { 29, false, 10, 2.10m, 9, 2.50m },
                    { 30, false, 1, 1.60m, 10, 1.90m },
                    { 31, false, 2, 14.00m, 11, 16.50m },
                    { 32, false, 3, 11.80m, 12, 13.20m },
                    { 33, false, 4, 17.00m, 13, 19.50m },
                    { 37, false, 8, 4.30m, 17, 5.00m },
                    { 38, false, 9, 5.90m, 18, 6.50m },
                    { 39, false, 10, 6.50m, 19, 8.00m },
                    { 40, false, 1, 9.20m, 20, 10.50m },
                    { 41, false, 9, 12.50m, 1, 14.00m },
                    { 42, false, 8, 8.00m, 2, 9.50m },
                    { 44, false, 6, 6.50m, 4, 8.00m },
                    { 49, false, 1, 2.50m, 9, 2.80m },
                    { 50, false, 10, 2.00m, 10, 2.20m },
                    { 51, false, 1, 7.50m, 19, 8.50m },
                    { 52, false, 2, 12.00m, 12, 13.90m },
                    { 53, false, 3, 5.70m, 5, 6.20m },
                    { 54, true, 4, 8.50m, 7, 10.00m },
                    { 55, false, 5, 10.90m, 1, 12.30m },
                    { 56, false, 6, 1.80m, 10, 2.10m },
                    { 57, true, 7, 6.80m, 16, 7.60m },
                    { 59, false, 9, 3.50m, 8, 4.00m },
                    { 60, false, 10, 2.10m, 9, 2.50m },
                    { 61, false, 1, 6.60m, 4, 7.90m },
                    { 62, false, 2, 13.00m, 11, 15.10m },
                    { 63, false, 3, 3.30m, 3, 3.90m },
                    { 64, false, 4, 3.80m, 14, 4.50m },
                    { 69, false, 9, 6.50m, 6, 7.30m },
                    { 70, false, 10, 6.00m, 18, 6.80m },
                    { 72, false, 6, 13.20m, 12, 14.80m },
                    { 73, false, 7, 2.10m, 10, 2.30m },
                    { 74, false, 8, 8.60m, 7, 9.90m },
                    { 75, false, 9, 5.20m, 5, 6.00m },
                    { 76, false, 10, 3.30m, 8, 3.80m },
                    { 78, false, 2, 2.00m, 9, 2.20m },
                    { 79, false, 3, 7.10m, 16, 7.90m },
                    { 81, false, 5, 16.00m, 13, 18.50m },
                    { 82, false, 6, 3.80m, 3, 4.20m },
                    { 83, false, 7, 5.80m, 15, 6.50m },
                    { 89, false, 4, 6.60m, 6, 7.10m },
                    { 90, false, 5, 4.20m, 14, 4.80m },
                    { 91, false, 6, 3.30m, 8, 3.90m },
                    { 92, false, 7, 7.00m, 4, 8.10m },
                    { 93, false, 8, 7.10m, 2, 7.90m },
                    { 94, false, 9, 13.50m, 12, 15.00m },
                    { 95, false, 10, 5.10m, 5, 5.70m },
                    { 96, false, 2, 1.80m, 10, 2.00m },
                    { 97, false, 3, 5.50m, 15, 6.00m },
                    { 98, true, 4, 8.00m, 7, 9.50m },
                    { 99, false, 5, 16.40m, 13, 17.90m },
                    { 100, false, 6, 6.20m, 18, 6.80m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_UsuarioId",
                table: "Carrinhos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinhos_CarrinhoId",
                table: "ItemCarrinhos",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCarrinhos_ItemId",
                table: "ItemCarrinhos",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrecos_MercadoId",
                table: "ItemPrecos",
                column: "MercadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrecos_ProdutoId",
                table: "ItemPrecos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_DepartamentoId",
                table: "Produtos",
                column: "DepartamentoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCarrinhos");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "ItemPrecos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
