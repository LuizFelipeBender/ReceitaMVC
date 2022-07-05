using Microsoft.EntityFrameworkCore.Migrations;

namespace SiteMVC.Migrations
{
    public partial class PopulaBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO `mvc`.`aspnetusers` (`Id`,`Nome`,`Sobrenome`,`Sobremim`,`FacebookLink`,`TwitterLink`,`UserName`,`NormalizedUserName`,`Email`,`NormalizedEmail`,`EmailConfirmed`,`PasswordHash`,`SecurityStamp`,`ConcurrencyStamp`,`PhoneNumber`,`PhoneNumberConfirmed`,`TwoFactorEnabled`,`LockoutEnd`,`LockoutEnabled`,`AccessFailedCount`) VALUES ('3b04aa33-0746-4762-8fa4-80e8dfc67286',NULL,NULL,NULL,NULL,NULL,'admin@gft.com','ADMIN@GFT.COM','admin@gft.com','ADMIN@GFT.COM',1,'AQAAAAEAACcQAAAAEHeqIuUFJPKkYaBe4wa+3uWUgPjIEwDU8e2bS988mjOQhNIKhqEYaJX3eydQ6SvKow==','5ZV3Q3DUR23AJ4HEXCBHODNDJVJ5HRAJ','2c6a215f-5069-4cce-bebe-afbcc13652ed',NULL,0,0,NULL,1,0);
            INSERT INTO `mvc`.`aspnetusers` (`Id`,`Nome`,`Sobrenome`,`Sobremim`,`FacebookLink`,`TwitterLink`,`UserName`,`NormalizedUserName`,`Email`,`NormalizedEmail`,`EmailConfirmed`,`PasswordHash`,`SecurityStamp`,`ConcurrencyStamp`,`PhoneNumber`,`PhoneNumberConfirmed`,`TwoFactorEnabled`,`LockoutEnd`,`LockoutEnabled`,`AccessFailedCount`) VALUES ('a4a1c751-168e-4b67-a373-82705130148d',NULL,NULL,NULL,NULL,NULL,'usuario@gft.com','USUARIO@GFT.COM','usuario@gft.com','USUARIO@GFT.COM',1,'AQAAAAEAACcQAAAAEN4W5n6ptqfUygUjRsXRBRPNY8PGLVx3LcTLfxzTx2n6C0+58hScuNWUS/YWXakmQg==','WMTCZEH6QYD35VCCFYZ7UZFXMOQ6GBZO','8a1f09ec-a18c-478d-90ce-4227d0de6d1b',NULL,0,0,NULL,1,0);");
            migrationBuilder.Sql(@"INSERT INTO `mvc`.`aspnetuserclaims`  (`Id`,`UserId`,`ClaimType`,`ClaimValue`) VALUES (2,'3b04aa33-0746-4762-8fa4-80e8dfc67286','IsAdmin','true');
            INSERT INTO `mvc`.`aspnetuserclaims`  (`Id`,`UserId`,`ClaimType`,`ClaimValue`) VALUES (3,'a4a1c751-168e-4b67-a373-82705130148d','IsAdmin','false');");
            migrationBuilder.Sql(@"INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (1,'açúcar');
            INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (2,'manteiga');
            INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (3,'chocolate em pó 50% cacau');
            INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (4,'farinha de trigo');
            INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (5,'sopa de fermento para bolo');
            INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (6,'sal');
            INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (7,'De um ótimo humor e sacadas geniais');
            INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (8,'Bife de carne');
            INSERT INTO `mvc`.`ingredientesmodels` (`Id`,`Ingrediente`) VALUES (9,'Pera');
            ");

            migrationBuilder.Sql(@"INSERT INTO `mvc`.`receitasmodels` (`Id`,`NomeReceita`,`ReceitaDescricao`,`TipoDeReceita`,`DataDeCriacao`,`AlteradoData`,`AutorId`) VALUES (1,'Bolo Fofinho de Nutella e Chocolate','Bolo é um alimento à base de massa de farinha, geralmente doce e cozido no forno. Os bolos são um dos componentes principais das festas, como as de aniversário e casamento, por vezes ornamentados artisticamente e ocupando o lugar central da mesa.',4,'2022-07-04 04:52:48.159243','2022-07-04 05:02:42.342483','3b04aa33-0746-4762-8fa4-80e8dfc67286');
INSERT INTO `mvc`.`receitasmodels` (`Id`,`NomeReceita`,`ReceitaDescricao`,`TipoDeReceita`,`DataDeCriacao`,`AlteradoData`,`AutorId`) VALUES (2,'Como Eu Conheci Sua Mãe','Ted se apaixonou. Tudo começou quando seu melhor amigo, Marshall, soltou a bomba de que planejava pedir em casamento a namorada de longa data, Lily, uma professora de jardim de infância. Ted percebeu que era melhor se mexer se esperava encontrar o verdadeiro amor. Para ajudá-lo na missão está Barney, um amigo com opiniões sem fim -- e às vezes absurdas --, uma queda por ternos e uma fórmula infalível para conhecer garotas. Quando Ted conhece Robin, tem certeza que é amor à primeira vista, mas o relacionamento esfria e se transforma em uma amizade.',1,'2022-07-04 05:06:50.372167','2022-07-04 05:45:41.573586','3b04aa33-0746-4762-8fa4-80e8dfc67286');
INSERT INTO `mvc`.`receitasmodels` (`Id`,`NomeReceita`,`ReceitaDescricao`,`TipoDeReceita`,`DataDeCriacao`,`AlteradoData`,`AutorId`) VALUES (3,'CARNE COM BRÓCOLIS E MOLHO DE SOJA','Esqueça o fast food - esta receita de carne com brócolis entrega todo o sabor sem os níveis insanos do sódio e gordura. É um prato vibrante, com inspiração asiática e que fica pronto em menos de 15 minutos.​\r\nO dia que resolvi testar essa receita foi por puro desespero e vontade. Só tinha um pedaço de carne na geladeira e estava com muita vontade de comer comida chinesa. La fui procurar receita de carne com inspiração asiática e que não demorasse horrores para ficar pronto. Achei essa receita por acaso em um blog dedicado a receitas anglo-asiáticas e foi paixão a primeira vista. heart\r\nOriginalmente essa receita não vai brócolis, mas como estou tentando aumentar meu consumo de vegetais acrescentei por conta e risco. Funcionou e agora só faço assim. Você pode acrescentar também cenoura, acelga, pimentão vermelho...\r\n\r\nEu adoro pedir comida no China in Box (China na caixinha para os intimos) mas ultimamente o sabor tem deixado a desejar. Estou desanimada com eles, confesso. Essa receita é perfeita para aqueles momentos em que eu com certeza pediria comida lá. Meu bolso e saúde estão agradecendo imensamente essa nova receita. Muito mais barato que pedir no China in Box, com muito menos sódio e açúcar que a versão pronta. E convenhamos, fica pronto em menos tempo que o delivery deles. cheeky',2,'2022-07-04 05:42:07.804199','2022-07-04 05:51:18.860060','3b04aa33-0746-4762-8fa4-80e8dfc67286');
");

migrationBuilder.Sql(@"INSERT INTO`mvc`.`receitainfomodels`(`Id`,`Rende`,`TempoPrep`,`TempCozinhamento`,`ServePessoa`,`FotoPath`,`ReceitaId`) VALUES (9,8,4,3,18,'ab7ca6d1-51b5-404a-9ce5-ecaa5266b1be_bolo-nutella-bolo-brigadeiro.jpg',1);
INSERT INTO `mvc`.`receitainfomodels` (`Id`,`Rende`,`TempoPrep`,`TempCozinhamento`,`ServePessoa`,`FotoPath`,`ReceitaId`) VALUES (12,11,8,10,94,'77fdba9b-4f40-44f3-bcb8-7aa9268d90d4_Capturar.PNG',2);
INSERT INTO `mvc`.`receitainfomodels` (`Id`,`Rende`,`TempoPrep`,`TempCozinhamento`,`ServePessoa`,`FotoPath`,`ReceitaId`) VALUES (14,9,6,15,7,'08beb8b5-a56b-4c92-bd16-9f110e607ab7_carne.jfif',3);
");
migrationBuilder.Sql(@"INSERT INTO `mvc`.`usuariofavoritasreceitas` (`UserId`,`ReceitaId`) VALUES ('3b04aa33-0746-4762-8fa4-80e8dfc67286',1);
INSERT INTO `mvc`.`usuariofavoritasreceitas` (`UserId`,`ReceitaId`) VALUES ('3b04aa33-0746-4762-8fa4-80e8dfc67286',2);
INSERT INTO `mvc`.`usuariofavoritasreceitas` (`UserId`,`ReceitaId`) VALUES ('3b04aa33-0746-4762-8fa4-80e8dfc67286',3);
");
            migrationBuilder.Sql(@"INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (1,1,'Primeiramente comece batendo em uma tigela o açúcar com o óleo e os ovos, por aproximadamente 2 minutos, pode usar a batedeira ou liquidificador.');
INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (2,1,'Em seguida acrescente a Nutella, o chocolate e o leite e misture bem até completa dissolução.');
INSERT INTO`mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (3,1,'Então adicione a farinha de trigo e o sal e misture até a massa ficar lisa.');
INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (4,1,'Assim feito acrescente o fermento para bolo e misture delicadamente.');
INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (5,1,'Logo depois despeje em forma de furo central de 20 cm de diâmetro por 8 cm de altura ( nós untamos apenas com margarina 80% lipídeos , mas se você quiser pode enfarinhar também).');
INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (6,1,'Em seguida leve ao forno preaquecido 180° e asse por 30 min aprox ( esse bolo cresce muito e fica bem leve ).');
INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (7,1,'Feito assim desenforme levemente morno e espere esfriar para decorar, sugerimos Nutella sobre o bolo e avelãs para decorar, agora é so comer');
INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (8,2,'Primeiramente comece batendo em uma tigela o açúcar com o óleo e os ovos, por aproximadamente 2 minutos, pode usar a batedeira ou liquidificador.');
INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (9,3,'Primeiramente comece batendo em uma tigela o açúcar com o óleo e os ovos, por aproximadamente 2 minutos, pode usar a batedeira ou liquidificador.');
INSERT INTO `mvc`.`instrucaomodels` (`Id`,`ReceitaId`,`Instrucao`) VALUES (10,3,'- Marinar a carne por 1 hora em 1 colher de chá de óleo, 1 colher de chá de molho de soja e 1 colher de sopa de amido de milho (você pode pular essa parte e só temperar a carne, o sabor fica melhor se marinar, mas tudo bem se não tiver esse tempo) . Passar a carne no restante do amido de milho (1/4 xícara), retire o excesso de amido de milho e reserve. ');
");





        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM aspnetusers");
            migrationBuilder.Sql("DELETE FROM aspnetuserclaims");
            migrationBuilder.Sql("DELETE FROM instrucaomodels");
            migrationBuilder.Sql("DELETE FROM ingredientesmodels");
            migrationBuilder.Sql("DELETE FROM receitainfomodels");
            migrationBuilder.Sql("DELETE FROM receitasmodels"); 
            migrationBuilder.Sql("DELETE FROM respostachat");       
            migrationBuilder.Sql("DELETE FROM usuariofavoritasreceitas"); 
        }
    }
}
