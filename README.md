# MacetimTools

# Ferramenta para o GTA V online

Esse programa não é um cheater (hack program), e não tenho intenção de fazer um, 
o MacetimTools é apenas uma ferramenta que tem a seguintes funcionalidades:

* Suspender o processo do GTA5.exe.

* Desconectar internet e reconectar em seguida.

* Análise de imagem do mini game da "digital do Lester" da Heist do Diamond Casino.

***Não utilizo nenhuma injeção de DLL ou alteração de dados de memória, apenas recursos nativos do windows para automatizar.
A análise da digital é totalmente propicia a falha, ele apenas compara a imagem atual do mini game e 
te indica um possível resultado para facilitar.***

![alt text](https://i.imgur.com/jamxTIG.png)

NOTAS:
Antes de utilizar a ferramenta de análise da digital, faça o download das imagens das digitais que são apenas verdadeiras, segue o link:

[Google Drive](https://drive.google.com/file/d/1jazL9dBK69CcO_r6zA5dZ8lsp4Msy2X_/view?usp=sharing)

Após abrir o MacetimTools, ele vai criar uma pasta em: "C:\Program Files\Macetim"
descompacte o "imagem_source_true.rar" e coloque APENAS as imagens na pasta criada com o nome de "True". Pronto.

OBS: A análise da digital **APENAS FUNCIONA** com a resolução 1920x1080 full screen. Futuramente adicionarei suporte a demais resoluções.
Lembrando que é apenas uma BETA.

## Task Lists
- [x] Desconectar a internet desativando o dispositivo a ser selecionado.
- [x] Criar de forma simples e otimizada sessão pública solo a partir do firewall adicionando regas.
- [ ] Identificador de rede no qual o usuário está conectado no momento e setar como padrão.
- [ ] GDI opcional para o minigame do cassino que funcione apenas em modo janela.
- [ ] Cronômetro interativo.


## Notas da versão v1.5d - BETA: 

* Alguns ajustes de performance.

* Correções: 

Digital não ficava organizada de forma crescente em alguns casos.

O programa inicializava de forma minimizada.

* Criado um método em que verifica quais redes estão ativas e cria uma lista para o usuário escolher.
