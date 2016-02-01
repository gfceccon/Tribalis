using UnityEngine;
using System.Collections;

public class EventsList : MonoBehaviour
{
    public static string defaultImg = "background";
    public enum Events
    {
        PreDC1,
        DC1Reli,
        DC1Merc,
        DC1Mili,
        DC1ReliLogA,
        DC1ReliLogB,
        DC1MercLogA,
        DC1MercLogB,
        DC1MiliLogA,
        DC1MiliLogB,
        PreDC2,
        DC2Reli,
        DC2Merc,
        DC2Mili,
        DC2ReliLogA,
        DC2ReliLogB,
        DC2MercLogA,
        DC2MercLogB,
        DC2MiliLogA,
        DC2MiliLogB,
        PreDC3,
        DC3Reli,
        DC3Merc,
        DC3Mili,
        DC3ReliLogA,
        DC3ReliLogB,
        DC3MercLogA,
        DC3MercLogB,
        DC3MilILogA,
        DC3MiliLogB,
        PreDC4,
        PreDC4Inclusivo,
        PreDC4Exclusivo,
        DC4Inclusivo,
        DC4Exclusivo,
        DC4InclusivoReli,
        DC4InclusivoMerc,
        DC4ExclusivoMerc,
        DC4ExclusivoMili,
        S1A,
        S1A1,
        S1A2,
        S1A1Log,
        S1A2Log,
        S1B,
        S1B1,
        S1B2,
        S1B1Log,
        S1B2Log,
        S1C,
        S1C1,
        S1C2,
        S1C3,
        S1C1Log,
        S1C2Log,
        S1C3Log,
        S2A,
        S2A1,
        S2A2,
        S2A1Log,
        S2A2Log,
        S2Ex,
        S2ExLog,
        S2B,
        S2B1,
        S2B2,
        S2B1Log,
        S2B2Log,
        S3A,
        S3A1,
        S3A2,
        //S3A1Log,
        //S3A2Log,
        S3B,
        S3B1,
        S3B2,
        S3B3,
        //S3B1Log,
        //S3B2Log,
        //S3B3Log,
        DC3MiliLogA,
        Size,
        None
    };


    public BitArray completed = new BitArray((int)Events.Size);
    public Event[] events = new Event[(int)Events.Size];

    [HideInInspector]
    public Events[] eventsOnTime;

    void Start()
    {
        eventsOnTime = new Events[]{
        Events.PreDC1,
        Events.DC1ReliLogA,
        Events.DC1ReliLogB,
        Events.DC1MercLogA,
        Events.DC1MercLogB,
        Events.DC1MiliLogA,
        Events.DC1MiliLogB,
        Events.S1A,
        Events.S1A1Log,
        Events.S1A2Log,
        Events.S1B,
        Events.S1B1Log,
        Events.S1B2Log,
        Events.S1C,
        Events.S1C1Log,
        Events.S1C2Log,
        Events.S1C3Log,
        Events.PreDC2,
        Events.DC2ReliLogA,
        Events.DC2ReliLogB,
        Events.DC2MercLogA,
        Events.DC2MercLogB,
        Events.DC2MiliLogA,
        Events.DC2MiliLogB,
        Events.S2A,
        Events.S2A1Log,
        Events.S2A2Log,
        Events.S2Ex,
        Events.S2ExLog,
        Events.S2B,
        Events.S2B1Log,
        Events.S2B2Log,
        Events.PreDC3,

        Events.DC3ReliLogA,
        Events.DC3ReliLogB,
        Events.DC3MercLogA,
        Events.DC3MercLogB,
        Events.DC3MilILogA,
        Events.DC3MiliLogB,
        Events.S3A,
        Events.S3B
        };

        events[(int)Events.PreDC1] = new Event(
            defaultImg,
            "Alguns clãs se juntaram em uma planície ao lado de um rio. Para comemorar, eles queriam fazer um ritual de oferenda aos deuses, mas estavam em dúvida sobre qual devia ser a tal oferenda. Qual escolher?",
            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option ("Coleta", Events.DC1Reli),
                new Option ("Pesca", Events.DC1Merc),
                new Option ("Caça", Events.DC1Mili)
            }
        );

        events[(int)Events.PreDC2] = new Event(
            "eclipse",
            "A Lua sobrepôs o Sol, em plena luz do dia. O fenômeno do eclipse solar aterrorizou a todos na tribo, que estavam com medo de que a luz nunca mais voltasse a brilhar no céu. Os sacerdotes, desesperados, pediam um ritual para acalmar a fúria dos deuses. O que fazer?",
            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option ("Sacrificar aldeão", Events.DC2Reli),
                new Option ("Construir monumento de ouro", Events.DC2Merc),
                new Option ("Sacrificar melhor soldado", Events.DC2Mili)
            }
        );

        events[(int)Events.PreDC3] = new Event(
            "primeira guerra",
            "Uma grande guerra instaurou-se. Tribos vizinhas juntaram-se para atacar a sua e outras ao redor, que também se aliaram. Depois de duras batalhas e muitas mortes, a sua tribo sagrou-se vitoriosa. O povo pede um ritual para comemorar este grande feito. O que fazer?",
            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option ("Homenagem aos deuses", Events.DC3Reli),
                new Option ("Grande banquete", Events.DC3Merc),
                new Option ("Competições entre guerreiros", Events.DC3Mili)
            }
        );

        events[(int)Events.PreDC4] = new Event(
            "",
            "Após guerras e contatos com outras tribos, o seu território não é apenas habitado por um único povo. Várias etnias se misturam, na língua, nos costumes e na própria feição das pessoas. Com uma das melhores colheitas dos últimos anos, um ritual precisa exaltar a prosperidade com uma ideologia. Qual seria?",
            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option ("Igualdade étnica", Events.PreDC4Inclusivo),
                new Option ("Afirmação cultural", Events.PreDC4Exclusivo)
            }
        );

        events[(int)Events.PreDC4Inclusivo] = new Event(
            "EC4Inclusivo",
            "Há gerações, o ritual do eclipse é realizado na tribo. Com a aprimoração técnica e artística da sua tribo, vocês decidem criar um novo monumento para engrandecer esse costume. O que fazer?",
            new Events[] { Events.DC4Inclusivo },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option ("Grande templo aos deuses", Events.DC4InclusivoReli),
                new Option ("Um templo digno de seu povo", Events.DC4InclusivoMerc)
            }
        );

        events[(int)Events.PreDC4Exclusivo] = new Event(
            "EC4Exclusivo",
            "Os últimos anos foram marcados por colheitas memoráveis, que trouxeram abundância de batatas à tribo. O povo pedia um ritual para comemorar toda essa prosperidade: um dia para utilizar as batatas e torná-los produtos ou fazer uma verdadeira guerra de batatas. O que fazer?",
            new Events[] { Events.DC4Exclusivo },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option ("Grande feira comercial", Events.DC4ExclusivoMerc),
                new Option ("Guerra de batatas", Events.DC4ExclusivoMili)
            }
        );

        // Acima, todas as escolhas-chave foram descritas (falta apenas determinar os efeitos numéricos)

        //Em seguida, os eventos de decisões-chave:

        // DC1:
        events[(int)Events.DC1Reli] = new Event(
            "oferenda coleta",
            "As plantações não foram suficientes para a oferenda desejada pela tribo. Com uma quantidade exorbitante de vegetais entregados aos deuses, os clãs reafirmavam a sua religião e começavam a ser conhecidos na região.",
            new Events[] { },
            1, 0, 0,
            2, 3, 1,
            new Option[] { }
        );

        events[(int)Events.DC1Merc] = new Event(
            "oferenda peixe",
            "Homens de todas as idades foram às margens do rio para pescar. Com uma quantidade exorbitante de peixes entregados aos deuses, os clãs reafirmavam a sua religião e começavam a ser conhecidos na região.",
            new Events[] { },
            0, 1, 0,
            2, 3, 1,
            new Option[] { }
        );

        events[(int)Events.DC1Mili] = new Event(
            "oferenda javali",
            "“A cada dia que passava, mais animais eram mortos nas redondezas da tribo. Com uma quantidade exorbitante de caças entregadas aos deuses, os clãs reafirmavam a sua religião e começavam a ser conhecidos na região.”",
            new Events[] { },
            0, 0, 1,
            2, 3, 1,
            new Option[] { }
        );

        // DC2:
        events[(int)Events.DC2Reli] = new Event(
            "DC2Reli",
            "Um menino, que acabava de se tornar homem, foi o escolhido para ser sacrificado: uma vida pelas outras. O sangue da tribo derramado no chão compadeceram os deuses. O Sol brilhou novamente no céu.",
            new Events[] { },
            1, 0, 0,
            -1, 0, 2,
            new Option[] { }
        );

        events[(int)Events.DC2Merc] = new Event(
            "DC2Merc",
            "Todo o ferro possível foi derretido e banhado a ouro para a criação de um imenso monumento em forma de esfera. O brilho desta estrela em terra compadeceram os deuses. O Sol brilharia para sempre no céu agora.",
            new Events[] { },
            0, 1, 0,
            0, -2, 2,
            new Option[] { }
        );

        events[(int)Events.DC2Mili] = new Event(
            "DC2Mili",
            "Os dois maiores guerreiros da tribo travaram uma grande luta: o vencedor iria ao céus em forma de sacrifício. O sangue da luta derramado no chão compadeceram os deuses. O Sol brilhou novamente no céu.",
            new Events[] { },
            0, 0, 1,
            -1, 0, 2,
            new Option[] { }
        );

        // DC3:
        events[(int)Events.DC3Reli] = new Event(
            "DC3Reli",
            "Uma grande estátua dos deuses foi erguida para uma cerimônia que se tornaria comum nas gerações seguintes. Com todos rogando e segurando velas, a força da religião naquele povo era mais do que perceptível.",
            new Events[] { },
            1, 0, 0,
            1, 1, 3,
            new Option[] { }
        );

        events[(int)Events.DC3Merc] = new Event(
            "DC3Merc",
            "Um grande banquete foi realizado no centro da tribo, com mais alimentos do que qualquer um ali já havia visto antes. Diante de toda aquela incrível festa, a força da riqueza naquele povo era mais do que perceptível.",
            new Events[] { },
            0, 1, 0,
            1, 1, 3,
            new Option[] { }
        );

        events[(int)Events.DC3Mili] = new Event(
            "DC3Mili",
            "Uma competição entre os guerreiros tornou-se o foco da atenção da tribo durante muitas luas, e por muitos anos. A procura pelo soldado mais forte, ágil e talentoso mostrava que a força do militarismo naquele povo era mais do que perceptível.",
            new Events[] { },
            0, 0, 1,
            1, 1, 3,
            new Option[] { }
        );

        // DC4:
        events[(int)Events.DC4Inclusivo] = new Event(
            "DC4Inclusivo",
            "Em torno da estátua dos deuses, um grande festival se instauraria por muitas gerações a partir de então. Colocando todas as etnias em igualdade, todas elas eram convidadas a rogar para os mesmos deuses e viver em harmonia.",
            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC4Exclusivo] = new Event(
            "DC4Exclusivo",
            "Em torno da estátua dos deuses, um grande festival se instauraria por muitas gerações a partir de então. Afirmando a superioridade de sua tribo, o povo já se sentia capaz de levar a sua cultura para outros, que ainda viviam na barbárie.",
            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC4InclusivoReli] = new Event(
            "DC4InclusivoReli",
            "Um templo maior do que qualquer homem já viu foi erguido para os deuses. Alguns se sentiam amedontrados, outros protegidos por tanto poder divino. Cultuá-los se tornou sinônimo de viver.",
            new Events[] { },
            1, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC4InclusivoMerc] = new Event(
            "DC4InclusivoMerc",
            "Um grande templo ocupava metros de extensão. Todas as artes e ciências se juntavam ali, mostrando a dimensão da criação humana. Uma identidade de espécie havia sido criada.",
            new Events[] { },
            0, 1, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC4ExclusivoMerc] = new Event(
            "DC4ExclusivoMerc",
            "O “Dia da Batata” tornou-se uma tradição na tribo, não apenas pelas criações que surgiam todos os anos com o tubérculo, mas pelo entreposto comercial que se formava. Com a abundância de outros produtos, eles também começaram a ser comercializados, como tecidos, caça e até escravos.",
            new Events[] { },
            0, 1, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC4ExclusivoMili] = new Event(
            "DC4ExclusivoMili",
            "Batatas foram esmagadas por vários dias de festa. Por muitos anos, essa cultura modificou-se até chegar em um ponto cruel: escravos, quando abundantes na tribo, eram mortos para treinamento de novos guerreiros.",
            new Events[] { },
            0, 0, 1,
            0, 0, 0,
            new Option[] { }
        );

        // Até aqui, todas as decisões-chave foram cobertas, mas ainda falta alterar os textos e as alterações de recursos

        // Logs dos eventos chave

        events[(int)Events.DC1ReliLogA] = new Event(
                defaultImg,
                "As pessoas da tribo melhoraram as técnicas de plantação e conseguiam produzir mais com menos terra.",

                new Events[] { Events.DC1Reli },
                0, 0, 0,
                0, 0, 0,
                new Option[] { }
            );

        events[(int)Events.DC1ReliLogB] = new Event(
            defaultImg,
            "De tempos em tempos, alguns começaram a fazer rituais particulares de oferecimento, para agradecer a boa colheita aos deuses.",

            new Events[] { Events.DC1Reli },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC1MercLogA] = new Event(
            defaultImg,
            "Barcos primitivos começaram a ser construídos pela tribo. Em pouco tempo, eles já conseguiam navegar por algumas horas ao longo do rio sem precisar voltar para casa.",

            new Events[] { Events.DC1Merc },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC1MercLogB] = new Event(
            defaultImg,
            "Grandes estoques de peixes foram feitos para a comemoração da chegada da nova estação, uma grande festa na margem do rio.",

            new Events[] { Events.DC1Merc },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC1MiliLogA] = new Event(
            defaultImg,
            "Alguns perceberam que certos metais poderiam ser moldados em formato de ponta, tornando-se instrumentos mais letais que as pedras lascadas das lanças.",

            new Events[] { Events.DC1Mili },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC1MiliLogB] = new Event(
            defaultImg,
            "Oferecer animais mortos tornou-se recorrente na tribo. Ao fim de um dia de caça, um dos bichos capturados era sempre sacrificado para agradecer aos deuses pelo sucesso.",

            new Events[] { Events.DC1Mili },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC2ReliLogA] = new Event(
            defaultImg,
            "Todos os anos, na noite mais longa do ano, a tribo repetia o ritual feito durante o eclipse. Um membro era sacrificado como oferta aos deuses para que o Sol se mantivesse vivo durante a vida das pessoas.",

            new Events[] { Events.DC2Reli },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC2ReliLogB] = new Event(
            defaultImg,
            "Foi feita uma grande cerimônia para escolher o que seria morto durante o ritual do eclipse. Os que se sentiam escolhidos pelos deuses deviam passar semanas dentro de uma caverna escura, bebendo apenas água.",

            new Events[] { Events.DC2Reli },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC2MercLogA] = new Event(
            defaultImg,
            "Uma tribo inimiga tentou roubar a grande bola de ouro. Caçadores e até camponeses defenderam o seu grande monumento como se fosse a sua própria vida.",

            new Events[] { Events.DC2Merc },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC2MercLogB] = new Event(
            defaultImg,
            "Em uma noite de forte tempestade, um implacável raio caiu em cima da bola de ouro, causando um incrível e estonteante brilho. Depois disso, seguiu-se várias luas de muita comemoração aos deuses.",

            new Events[] { Events.DC2Merc },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC2MiliLogA] = new Event(
            defaultImg,
            "Todos os anos, na noite mais longa do ano, a tribo repetia o ritual feito durante o eclipse. O maior dos guerreiros vencia uma luta e era sacrificado como oferta aos deuses para que o Sol mantivesse vivo durante a vida das pessoas.",

            new Events[] { Events.DC2Mili },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC2MiliLogB] = new Event(
            defaultImg,
            "As lutas tornavam-se um verdadeiro evento social da tribo, que era agora antecedida por um grande banquete de comemoração. As famílias dos que não conseguiam vencer carregavam esse fardo pelas próximas gerações.",

            new Events[] { Events.DC2Mili },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC3ReliLogA] = new Event(
            defaultImg,
            "Uma grande construção foi feita para abrigar rituais religiosos. Tornou-se costume da tribo visitá-la para rogar e agradecer aos deuses",

            new Events[] { Events.DC3Reli },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC3ReliLogB] = new Event(
            defaultImg,
            "A cada ano que passava, a quantidade de pessoas que participavam dos rituais religiosos aumentava. A crença se espalhava mais rápido do que se podia imaginar.",

            new Events[] { Events.DC3Reli },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC3MercLogA] = new Event(
            defaultImg,
            "Passavam-se os anos e o banquete ficava ainda maior. Alimentos de lugares distantes eram comprados apenas para festejar a fartura e a prosperidade.",

            new Events[] { Events.DC3Merc },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC3MercLogB] = new Event(
            defaultImg,
            "As tribos aliadas foram convidadas para participar do banquete. O que era um ritual da tribo acabou se tornando uma verdadeira comemoração daquela região.",

            new Events[] { Events.DC3Merc },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC3MiliLogA] = new Event(
            defaultImg,
            "Novas modalidades eram criadas para provar a existência de um guerreiro perfeito. Lutar, correr, nadar, pular e atirar eram habilidades testadas ao extremo pelos participantes.",

            new Events[] { Events.DC3Mili },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC3MiliLogB] = new Event(
            defaultImg,
            "O grande vencedor conseguia um lugar de destaque na tribo. Além de conseguir fartura de alimentos, ele era o responsável por coordenar uma defesa contra um ataque das tribos inimigas.",

            new Events[] { Events.DC3Mili },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        // Eventos secundários

        events[(int)Events.S1A] = new Event(
            defaultImg,
            "Os ventos do Norte anunciam o inesperado: um rigoroso inverno se aproxima. Alguns sugerem a caça de animais perigosos para usar suas peles, outros veem nos abrigos a salvação nestes tempos. O que fazer?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Caçar animais", Events.S1A1),
                new Option("Construir abrigos", Events.S1A2)
            }
        );

        events[(int)Events.S1A1] = new Event(
            defaultImg,
            "A caça, apesar dos pesares, foi considerada um sucesso. Algumas peles agora vão tornar o inverno uma época menos mortal. Infelizmente, alguns morreram enfrentando animais ainda desconhecidos pela tribo.",

            new Events[] { },
            0, 0, 0,
            -1, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S1A1Log] = new Event(
            defaultImg,
            "Mais pessoas morreram por não aguentarem o frio, mesmo dentro de seus precários abrigos. Os qu ainda sobrevivem estão perdendo as esperanças.",

            new Events[] { Events.S1A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S1A2] = new Event(
            defaultImg,
            "A construção dos abrigos não saiu como esperado. Muitos recursos foram perdidos pela falta de experiência e técnica, mas os poucos que ficaram em pé abrigam agora a tribo, mesmo que desconfortavelmente.",

            new Events[] { },
            0, 0, 0,
            0, -1, 0,
            new Option[] { }
        );

        events[(int)Events.S1A2Log] = new Event(
            defaultImg,
            "A quantidade de pessoas que morreram por causa do frio diminuiram, mas a alimentação já começa a ficar escassa e preocupante.",

            new Events[] { Events.S1A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S1B] = new Event(
            defaultImg,
            "As peles conseguiram abrigar alguns, mas muitos na tribo continuam sofrendo com o inverno. Disputas pelo único recurso que eles têm para enfrentar o clima estão se tornando cada vez mais frequentes e até sangrentas. O que fazer?",

            new Events[] { Events.S1A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Apoiar os conflitos", Events.S1B1),
                new Option("Aumentar a caça", Events.S1B2)
            }
        );

        events[(int)Events.S1B1] = new Event(
            defaultImg,
            "Os conflitos continuaram ainda por alguns meses, até que o inverno desse, finalmente, uma trégua. Por mais que poucos tenham morrido por esse motivo, uma sensação amarga se estabeleceu na tribo após esse episódio.",

            new Events[] { },
            0, 0, 0,
            0, 0, -1,
            new Option[] { }
        );

        events[(int)Events.S1B1Log] = new Event(
            defaultImg,
            "Algumas crianças de clãs mais pobres morreram de hipotermia, já que não tem nenhuma proporção disponível. Por outro lado, o clã mais importante continuava crescendo em população e recursos.",

            new Events[] { Events.S1B1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S1B2] = new Event(
            defaultImg,
            "Novamente, a caça foi considerada um sucesso. Agora com mais experiência, a tribo conseguiu peles suficientes para aquecer a todos e, ainda, capturou algumas novas espécies que puderam servir como alimento.",

            new Events[] { },
            0, 0, 0,
            0, 1, 0,
            new Option[] { }
        );

        events[(int)Events.S1B2Log] = new Event(
            defaultImg,
            "As peles começaram a ser curtidas antes de serem usadas, dando mais conforto aos habitantes da tribo. A abundância delas permitiu que essa descoberta fosse feita.",

            new Events[] { Events.S1B2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S1C] = new Event(
            defaultImg,
            "Os abrigos serviram bem para a tribo, mas as pessoas que estão neles precisam comer, de alguma forma. Um pequeno estoque de alimentos pode ser usado para esse fim, mas alguns sugerem uma plantação ou novas caçadas. O que fazer?",

            new Events[] { Events.S1A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Usar o estoque", Events.S1C1),
                new Option("Plantar", Events.S1C2),
                new Option("Sair à caça", Events.S1C3)
            }
        );

        events[(int)Events.S1C1] = new Event(
            defaultImg,
            "O inverno se foi, juntamente com todo o alimento guardado pela tribo nos últimos meses em que o Sol ainda ardia sobre suas peles. Todos estão vivos, mas precisam voltar ao trabalho para continuar a sobreviver.",

            new Events[] { },
            0, 0, 0,
            0, -2, 0,
            new Option[] { }
        );

        events[(int)Events.S1C1Log] = new Event(
            defaultImg,
            "Para suprir a falta de mantimentos, alguns começaram pequenas plantações particulares. Poucas realmente sobreviveram ao tempo e conseguiram manter as famílias.",

            new Events[] { Events.S1C1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S1C2] = new Event(
            defaultImg,
            "Não faltaram esforços para manter uma plantação, mas o clima gelado foi implacável e nada nasceu. Com muita dificuldade, a tribo realmente sobreviveu, racionalizando a pouca comida disponível.",

            new Events[] { },
            0, 0, 0,
            0, 0, -1,
            new Option[] { }
        );

        events[(int)Events.S1C2Log] = new Event(
            defaultImg,
            "Um grande tremor de terra aconteceu durante a noite e deixou todos muito assustados. A tribo acreditava que isso era um sinal da insatisfação dos deuses.",

            new Events[] { Events.S1C2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S1C3] = new Event(
            defaultImg,
            "As caçadas de inverno conseguiram, enfim, abastecer os abrigos da tribo, mas a um custo alto: a experiência de combate não foi suficiente para poupar algumas vidas durante a busca por comida.",

            new Events[] { },
            0, 0, 0,
            1, -1, 0,
            new Option[] { }
        );

        events[(int)Events.S1C3Log] = new Event(
            defaultImg,
            "Alguns caçadores guardam, na frente de suas casas, crânios de perigosos animais, como um verdadeiro troféu de suas conquistas.",

            new Events[] { Events.S1C3 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S2A] = new Event(
            defaultImg,
            "A prosperidade dos últimos tempos levou a um grande crescimento populacional na tribo, deixando a situação territorial e alimentícia complicada. Os mais cautelosos sugerem um melhor aproveitamento do território; os mais corajosos querem uma expedição para procurar novos locais. O que fazer?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Aproveitar o território", Events.S2A1),
                new Option("Fazer uma expedição", Events.S2A2)
            }
        );

        events[(int)Events.S2A1] = new Event(
            defaultImg,
            "Qualquer porção de terra era usado pela tribo para moradia ou alimentação. Lentamente, a crescente população alcançava condições favoráveis para viver novamente em seus padrões.",

            new Events[] { },
            0, 0, 0,
            0, 1, 0,
            new Option[] { }
        );

        events[(int)Events.S2A1Log] = new Event(
            defaultImg,
            "Uma espécie de javali ficou mais rara na região da tribo. Costumes de uma comemoração, que costumava ter grandes banquetes dessa carne, foram sendo alterados com o tempo.",

            new Events[] { Events.S2A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S2A2] = new Event(
            defaultImg,
            "Uma grande mobilização foi feita, tanto para agrupar os bens materiais necessários para a viagem, quanto para escolher os mais valentes que desbravariam terras desconhecidas. A tribo espera receber notícias em breve sobre o resultado da expedição.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S2A2Log] = new Event(
            defaultImg,
            "Um grande tremor de terra aconteceu durante a noite e deixou todos muito assustados. A tribo acreditava que isso era um sinal da insatisfação dos deuses.",

            new Events[] { Events.S2A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S2Ex] = new Event(
            defaultImg,
            "Nos primeiros anos, aproveitar o máximo possível do território tinha sido uma solução, mas a natureza não conseguia se restaurar na mesma velocidade. Décadas depois, a tribo sofria com uma crise ainda maior de recursos, que se manteria até o reestabelecimento do meio ambiente.",

            new Events[] { Events.S2A2 },
            0, 0, 0,
            0, -2, 0,
            new Option[] { }
        );

        events[(int)Events.S2ExLog] = new Event(
            defaultImg,
            "Apenas algumas espécies de vegetais conseguiam nascer na terra pobre que se formara ali. A maioria delas eram verdadeiras pragas, que eram descartadas em outras épocas e, hoje, serviam como alimento.",

            new Events[] { Events.S2Ex },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S2B] = new Event(
            defaultImg,
            "Um mensageiro aparece na tribo, trazendo informações da expedição enviada anos atrás. Segundo ele, um lugar não habitado foi encontrado e pode ser útil para resolver os problemas do povo. Resultado de má administração dos recursos que tinham, precisam de novos mantimentos, juntamente com a decisão dos que ficaram. O que fazer com a nova terra?",

            new Events[] { Events.S2A2 },
            0, 0, 0,
            -1, -1, 0,
            new Option[] {
                new Option("Extrair recursos", Events.S2B1),
                new Option("Expandir territorialmente", Events.S2B2)
            }
        );

        events[(int)Events.S2B1] = new Event(
            defaultImg,
            "Caravanas chegavam com recursos da terra descoberta, abastecendo a tribo de forma considerável. A continuidade dessa prática daria segurança à prosperidade do povo.",

            new Events[] { },
            0, 0, 0,
            0, 2, 0,
            new Option[] { }
        );

        events[(int)Events.S2B1Log] = new Event(
            defaultImg,
            "Novas reservas de ouro e prata foram encontradas nessa nova terra. A extração começaria em breve, trazendo muitas riquezas para a tribo.",

            new Events[] { Events.S2B1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S2B2] = new Event(
            defaultImg,
            "Décadas após a primeira expedição, era impressionante a dimensão que a tribo havia tomado. A população e as plantações acompanharam a expansão territorial, levando a prosperidade a níveis nunca antes conquistados na história daquele povo.",

            new Events[] { },
            0, 0, 0,
            0, 0, 1,
            new Option[] { }
        );

        events[(int)Events.S2B2Log] = new Event(
            defaultImg,
            "Novas reservas de ouro e prata foram encontradas nessa nova terra. A extração começaria em breve, trazendo muitas riquezas para a tribo.",

            new Events[] { Events.S2B2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S3A] = new Event(
            defaultImg,
            "Um mensageiro de uma tribo aliada chega ofegante com a informação de que o seu povo será atacado em breve por um inimigo em comum. A sua ajuda é requisitada e, dado o apoio deles, é impossível recusar. O que fazer?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Negociar o ataque", Events.S3A1),
                new Option("Entrar na guerra", Events.S3A2)
            }
        );

        events[(int)Events.S3A1] = new Event(
            defaultImg,
            "Depois de algumas longas discussões, a sua tribo conseguiu impedir o ataque ao aliado, oferecendo uma boa quantia de recursos em troca. A paz reinava novamente.",

            new Events[] { },
            0, 0, 0,
            0, -1, 0,
            new Option[] { }
        );

        // falta S3A1Log

        events[(int)Events.S2A2] = new Event(
            defaultImg,
            "Esperada por alguns e temida por todos, a possibilidade de uma guerra não era apenas iminente e, em pouco tempo, se tornaria realidade.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        // falta S3A2Log

        events[(int)Events.S3B] = new Event(
            defaultImg,
            "Em uma reunião com a tribo aliada, estavam sendo decididas as estratégias de ataque para vencer a guerra. Para maximizar a força, era um consenso focar em apenas uma das várias cogitadas. Qual tática usar?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Atacar imediatamente", Events.S3B1),
                new Option("Usar o terreno ao seu favor", Events.S3B2),
                new Option("Intimidar com uma invocação aos deuses", Events.S3B3)
            }
        );

        events[(int)Events.S3B1] = new Event(
            defaultImg,
            "Um ataque imediato já era esperado pelos seus inimigos. Sua habilidade militar apenas amenizou a perda de guerreiros e mantimentos. O fracasso na batalha foi um dos piores fardos que sua tribo terá de carregar.",

            new Events[] { },
            0, 0, 0,
            -1, 0, 0,
            new Option[] { }
        );

        // falta S3B1Log

        events[(int)Events.S3B2] = new Event(
            defaultImg,
            "Os seus inimigos não esperavam a habilidade que teriam dentro de seu próprio território. Com movimentos rápidos e sucintos, não foram capazes apenas de vencer a guerra.",

            new Events[] { },
            0, 0, 0,
            1, 0, 1,
            new Option[] { }
        );

        // falta S3B2Log

        events[(int)Events.S3B3] = new Event(
            defaultImg,
            "A fé de sua tribo era muito maior do qualquer inimigo poderia esperar. Uma grande cerimônia foi realizada dias antes do ataque, intimidando completamente os atacantes. Uma parte deles ainda se converteu e foi morar em um pequeno clã amigo.",

            new Events[] { },
            0, 0, 0,
            1, 0, 1,
            new Option[] { }
        );

        // falta S3B3Log
    }

}