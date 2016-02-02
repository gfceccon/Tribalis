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
        DC3MiliLogA,
        DC3MiliLogB,
        PreDC4,
        PreDC4Inclusivo,
        PreDC4Exclusivo,
        DC4Inclusivo,
        DC4Exclusivo,
        DC4InclusivoLog,
        DC4ExclusivoLog,
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
        S7A,
        S7A1,
        S7A2,
        S7A3,
        S7A1Log,
        S7A2Log,
        S7A3Log,
        S7B,
        S7B1,
        S7B2,
        S7B1Log,
        S7B2Log,
        S7C,
        S7C1,
        S7C2,
        S7C1Log,
        S7C2Log,
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
        S5A,
        S5A1,
        S5A2,
        S5A1Log,
        S5A2Log,
        S5B,
        S5B1,
        S5B2,
        S5B3,
        S5B1Log,
        S5B2Log,
        S5B3Log,
        S6A,
        S6A1,
        S6A2,
        S6A1Log,
        S6A2Log,
        S6B,
        S6B1,
        S6B2,
        S6B3,
        S6B1Log,
        S6B2Log,
        S6B3Log,
        S3A,
        S3A1,
        S3A2,
        S3A1Log,
        S3A2Log,
        S3B,
        S3B1,
        S3B2,
        S3B1Log,
        S3B2Log,
        S3C,
        S3C1,
        S3C2,
        S3C1Log,
        S3C2Log,
        GoodEndReli,
        GoodEndMerc,
        GoodEndMili,
        BadEndPess,
        BadEndPess2,
        BadEndPess3,
        BadEndRecu,
        BadEndRecu2,
        BadEndRecu3,
        BadEndMora,
        BadEndMora2,
        BadEndMora3,
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
		Events.S7A,
		Events.S7A1Log,
		Events.S7A2Log,
		Events.S7A3Log,
		Events.S7B,
		Events.S7B1Log,
		Events.S7B2Log,
		Events.S7C,
		Events.S7C1Log,
		Events.S7C2Log,
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
		Events.S5A,
		Events.S5A1Log,
		Events.S5A2Log,
		Events.S5B,
		Events.S5B1Log,
		Events.S5B2Log,
		Events.S5B3Log,
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
        Events.DC3MiliLogA,
        Events.DC3MiliLogB,
		Events.S3A,
		Events.S3A1Log,
		Events.S3A2Log,
        Events.S6A,
		Events.S6A1Log,
        Events.S6A2Log,
		Events.S6B,
		Events.S6B1Log,
        Events.S6B2Log,
        Events.S6B3Log,
		Events.S3B,
		Events.S3B1Log,
		Events.S3B2Log,
		Events.S3C,
		Events.S3C1Log,
		Events.S3C2Log,
		Events.PreDC4,
		Events.DC4InclusivoLog,
		Events.DC4ExclusivoLog,
		Events.PreDC4Inclusivo,
		Events.PreDC4Exclusivo
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

        // Acima, todas as escolhas-chave foram descritas

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
            "sacrificio humano",
            "Um menino, que acabava de se tornar homem, foi o escolhido para ser sacrificado: uma vida pelas outras. O sangue da tribo derramado no chão compadeceram os deuses. O Sol brilhou novamente no céu.",
            new Events[] { },
            1, 0, 0,
            -1, 0, 2,
            new Option[] { }
        );

        events[(int)Events.DC2Merc] = new Event(
            "bola de ouro",
            "Todo o ferro possível foi derretido e banhado a ouro para a criação de um imenso monumento em forma de esfera. O brilho desta estrela em terra compadeceram os deuses. O Sol brilharia para sempre no céu agora.",
            new Events[] { },
            0, 1, 0,
            0, -2, 2,
            new Option[] { }
        );

        events[(int)Events.DC2Mili] = new Event(
            "sacrificio melhor guerreiro",
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
            "comemoracao jogos olimpicos",
            "Uma competição entre os guerreiros tornou-se o foco da atenção da tribo durante muitas luas, e por muitos anos. A procura pelo soldado mais forte, ágil e talentoso mostrava que a força do militarismo naquele povo era mais do que perceptível.",
            new Events[] { },
            0, 0, 1,
            1, 1, 3,
            new Option[] { }
        );

        // DC4:
        events[(int)Events.DC4Inclusivo] = new Event(
            "festa inclusiva",
            "Em torno da estátua dos deuses, um grande festival se instauraria por muitas gerações a partir de então. Colocando todas as etnias em igualdade, todas elas eram convidadas a rogar para os mesmos deuses e viver em harmonia.",
            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.DC4Exclusivo] = new Event(
            "festa exclusiva",
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
            "dia da batata",
            "O \"Dia da Batata\" tornou-se uma tradição na tribo, não apenas pelas criações que surgiam todos os anos com o tubérculo, mas pelo entreposto comercial que se formava. Com a abundância de outros produtos, eles também começaram a ser comercializados, como tecidos, caça e até escravos.",
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
		
		events[(int)Events.DC4InclusivoLog] = new Event(
            defaultImg,
            "O ato de trocar recursos por metais preciosos tornou-se comum na tribo. Alguns iam a outras tribos para realizar esse trabalho, outros os acompanhavam para disseminar a fé nos deuses.",

            new Events[] { Events.DC4Inclusivo },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.DC4ExclusivoLog] = new Event(
            defaultImg,
            "A visão de superioridade tornou-se comum na tribo, ao ponto de realizar ataques em outras tribos para forçar relações econômicas. Em algumas destas investidas, boa parte dos povos eram escravizados para trabalharem em função do povo “superior”.",

            new Events[] { Events.DC4Exclusivo },
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
		
		events[(int)Events.S7A] = new Event(
            defaultImg,
            "Foram avistados, circundando a tribo, estranhas criaturas selvagens. O povo, mesmo maravilhado com esses animais, foi tomado por um generalizado sentimento de medo e desespero. O que fazer?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Esconder-se", Events.S7A1),
                new Option("Atacá-los", Events.S7A2),
				new Option("Alimentá-los", Events.S7A3)
            }
        );

        events[(int)Events.S7A1] = new Event(
            defaultImg,
            "Com a aproximação dos animais, o desespero tornou-se pânico e todos começaram a se esconder daquelas estranhas criaturas. Além do terror instaurado na tribo, a morte de alguns durante a agitação foi inevitável.",

            new Events[] { },
            0, 0, 0,
            -1, 0, -1,
            new Option[] { }
        );
		
		events[(int)Events.S7A2] = new Event(
            defaultImg,
            "Via-se, saindo da tribo, apenas guerreiros enfurecidos em destruir a ameaça que os confrontava. Enquanto mais uma manada se aproximava, muitos dos animais foram rapidamente capturados.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S7A3] = new Event(
            defaultImg,
            "Gastar os alimentos que poderiam servir à tribo com estranhas criaturas parecia loucura pela visão de alguns, mas foi uma boa estratégia. As feições de ataque dos animais deram lugar a inesperadas expressões de docilidade.",

            new Events[] { },
            0, 0, 0,
            0, -1, 0,
            new Option[] { }
        );

        events[(int)Events.S7A1Log] = new Event(
            defaultImg,
            "Alguns meses foram necessários para que os animais se espalhassem para outros locais, amenizando o emocional dos mais fracos da tribo.",

            new Events[] { Events.S7A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S7A2Log] = new Event(
            defaultImg,
            "Dormir não era mais uma condição favorável. As criaturas que continuavam circundando a tribo uivavam durante toda a noite, aumentando ainda mais o pavor das pessoas.",

            new Events[] { Events.S7A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S7A3Log] = new Event(
            defaultImg,
            "Uma das criaturas conseguiu fugir no meio da noite e destruiu cestos de vegetais que iriam abastecer um dos clãs da tribo. Como vingança, eles mataram alguns outros animais, em segredo, para se alimentar.",

            new Events[] { Events.S7A3 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S7B] = new Event(
            defaultImg,
            "Passaram-se alguns dias e as criaturas continuam aparecendo nos arredores da tribo, deixando ainda um sentimento de apreensão no ar. A maioria da tribo espera que os guerreiros voltem aos campos e tragam mais animais como alimento, mas alguns dizem que matar os capturados podem afugentar os que ainda circundam. O que fazer com eles?",

            new Events[] { Events.S7A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Usá-los como alimento", Events.S7B1),
                new Option("Afugentar os outros", Events.S7B2)
            }
        );

        events[(int)Events.S7B1] = new Event(
            defaultImg,
            "Depois de mais alguns dias de enfrentamento, as criaturas pararam de passar pela tribo e a reserva de carne recebeu um grande aumento, com a morte dos animais capturados.",

            new Events[] { },
            0, 0, 0,
            0, 1, 0,
            new Option[] { }
        );
		
		events[(int)Events.S7B2] = new Event(
            defaultImg,
            "Animais empalados em estacas de madeira circundavam a tribo. A técnica não apenas afugentou as temidas criaturas, mas também materializou a força da qual os guerreiros tanto se orgulhavam.",

            new Events[] { },
            0, 0, 0,
            0, 0, 1,
            new Option[] { }
        );
		
		events[(int)Events.S7B1Log] = new Event(
            defaultImg,
            "A carne dessas novas criaturas dava mais energia e sustento aos caçadores, que podiam ficar mais tempo caçando e trazendo recursos para a tribo. Até os camponeses melhoraram sua produção.",

            new Events[] { Events.S7B1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S7B2Log] = new Event(
            defaultImg,
            "Caçadores de uma tribo vizinha foram avistados perto das plantações, segurando lanças e escudos. As carcaças das criaturas acabaram por afugentá-los.",

            new Events[] { Events.S7B2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S7C] = new Event(
            defaultImg,
            "Há alguns dias, o sentimento de medo deu lugar à curiosidade. As criaturas pareciam gostar da presença e dos agrados dados pela tribo e, acima de tudo, continuavam fascinando a todos. O que fazer com elas?",

            new Events[] { Events.S7A3 },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Tentar domesticá-los", Events.S7C1),
                new Option("Matar como alimento", Events.S7C2)
            }
        );

        events[(int)Events.S7C1] = new Event(
            defaultImg,
            "Os peculiares animais tinham a selvageria muito intrínsecas e uma tentativa de domesticá-los foi em vão. Mesmo assim, a relação entre eles e a tribo se mantinha favorável: as criaturas, de tempos em tempos, passavam por ali e as pessoas se sentiam protegidas por seus novos companheiros.",

            new Events[] { },
            0, 0, 0,
            0, 0, 1,
            new Option[] { }
        );
		
		events[(int)Events.S7C2] = new Event(
            defaultImg,
            "Era inegável a quantidade de alimento conseguida com a morte das criaturas, mas a religiosidade do povo não viu aquela prática com bons olhos. Os que tinham mais fé até se negavam em digerir a carne daqueles animais abençoados pelos deuses.",

            new Events[] { },
            0, 0, 0,
            0, 1, -1,
            new Option[] { }
        );
		
		events[(int)Events.S7C1Log] = new Event(
            defaultImg,
            "Caçadores de uma tribo vizinha foram avistados perto das plantações, segurando lanças e escudos. Uma das criaturas, que veio aos camponeses conseguir comida, atacou-os, afugentando os invasores.",

            new Events[] { Events.S7C1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S7C2Log] = new Event(
            defaultImg,
            "A prática de usar animais como oferenda foi abandonada com o tempo, depois do episódio com as criaturas. Eles eram usados apenas em ocasiões muito especiais, como o fim da colheita.",

            new Events[] { Events.S7C2 },
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
		
		events[(int)Events.S5A] = new Event(
            defaultImg,
            "Por conta de uma sucessão infeliz de más colheitas, a fartura deixou de fazer parte do dia a dia da tribo. Alimentar-se virou apenas uma questão de sobrevivência e lutas entre clãs para conseguir recursos tornaram-se mais comuns. O que fazer diante desse cenário?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Incentivar as lutas", Events.S5A1),
                new Option("Resolver pacificamente", Events.S5A2)
            }
        );

        events[(int)Events.S5A1] = new Event(
            defaultImg,
            "Lutar para se alimentar tornou-se hábito na tribo, chegando a causar mortes. Os poucos alimentos, advindos de caças e pescas mal-sucedidas e colheitas fracas, estão na mão daqueles que podem dominar os demais.",

            new Events[] { },
            0, 0, 0,
            -1, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S5A2] = new Event(
            defaultImg,
            "Após alguns meses de afloradas discussões, os clãs chegaram a um consenso sobre a divisão de seus recursos, alcançando, novamente, um equilíbrio coletivo, mesmo que, para isso, parte dos estoques feitos para o inverno tivessem de ser usados.",

            new Events[] { },
            0, 0, 0,
            0, -1, 1,
            new Option[] { }
        );

        events[(int)Events.S5A1Log] = new Event(
            defaultImg,
            "Nada parecia funcionar para que as colheitas voltassem a ser prósperas. Os que eram mais pobres, pela falta de alimento, já começavam a comer a própria terra, a única coisa em abundância naqueles tempos.",

            new Events[] { Events.S5A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S5A2Log] = new Event(
            defaultImg,
            "Com climas e chuvas constantes, foi apenas questão de tempo para que as colheitas voltassem a ser prósperas. Aos poucos, a tribo voltava a ter uma abundância de recursos vista apenas por seus antepassados.",

            new Events[] { Events.S5A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S5B] = new Event(
            defaultImg,
            "As disputas por comida estão insustentáveis e chegarão ao estado de barbárie em pouco tempo. Um pequeno grupo é passivo diante deste cenário, mas a maioria da tribo quer o fim das lutas, seja por meios pacíficos ou violentos. O que fazer?",

            new Events[] { Events.S5A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Impor com normas", Events.S5B1),
                new Option("Coagir com violência", Events.S5B2),
				new Option("Ficar passivo às lutas", Events.S5B3)
            }
        );

        events[(int)Events.S5B1] = new Event(
            defaultImg,
            "Alguns anos se passaram até que todos os clãs aceitassem as normas e uma certa paz voltasse a se instaurar na tribo, principalmente ao sentir a mudança de atmosfera que o fim das lutas proporcionou ao povo.",

            new Events[] { },
            0, 0, 0,
            0, 0, 1,
            new Option[] { }
        );
		
		events[(int)Events.S5B2] = new Event(
            defaultImg,
            "Em pouco tempo, as lutas foram apaziguadas e os alimentos passaram a ser distribuídos em um autoritário sistema de racionalização. Por mais que não houvessem mais disputas, o povo se sentia coagido a aceitar o que se formara.",

            new Events[] { },
            0, 0, 0,
            0, 0, -1,
            new Option[] { }
        );
		
		events[(int)Events.S5B3] = new Event(
            defaultImg,
            "Felizmente, a prosperidade chegou á vida da tribo antes da barbárie, mas não antes de muitas pessoas serem mortas em lutas ou de fome, instaurando uma atmosfera de medo de que tal situação voltasse a ocorrer.",

            new Events[] { },
            0, 0, 0,
            0, -1, -1,
            new Option[] { }
        );
		
		events[(int)Events.S5B1Log] = new Event(
            defaultImg,
            "A distribuição de água, após alguns períodos de baixa do rio, também se tornaram problema. A extensão das normas a esta nova questão foi natural e ocorreram pouquíssimos conflitos armados.",

            new Events[] { Events.S5B1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S5B2Log] = new Event(
            defaultImg,
            "A distribuição de água, após alguns períodos de baixa do rio, também se tornaram problema. A extensão do autoritarismo a esta nova questão foi natural e muitas pessoas acabaram fugindo da tribo por não suportar a situação.",

            new Events[] { Events.S5B2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S5B3Log] = new Event(
            defaultImg,
            "A distribuição de água, após alguns períodos de baixa do rio, também se tornaram problema. O medo da bárbarie tomou conta novamente da tribo, que brigava pelo controle de certos canais.",

            new Events[] { Events.S5B3 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S6A] = new Event(
            defaultImg,
            "Um mensageiro de uma tribo aliada chega ofegante com a informação de que o seu povo será atacado em breve por um inimigo em comum. A sua ajuda é requisitada e, dado o apoio deles, é impossível recusar. O que fazer?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Negociar o ataque", Events.S6A1),
                new Option("Entrar em guerra", Events.S6A2)
            }
        );

        events[(int)Events.S6A1] = new Event(
            defaultImg,
            "Depois de algumas longas discussões, a sua tribo conseguiu impedir o ataque ao aliado, oferecendo uma boa quantia de recursos em troca. A paz reinava novamente.",

            new Events[] { },
            0, 0, 0,
            0, -1, 0,
            new Option[] { }
        );

        events[(int)Events.S6A1Log] = new Event(
            defaultImg,
            "A tribo aliada enviou um presente a sua para agradecer a ajuda na negociação com o inimigo. Laços fortes entres os povos estão se firmando.",

            new Events[] { Events.S6A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S6A2] = new Event(
            defaultImg,
            "Esperada por alguns e temida por todos, a possibilidade de uma guerra já era iminente e, em pouco tempo, se tornaria realidade.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S6A2Log] = new Event(
            defaultImg,
            "Uma grande tempestade ocorreu durante os preparativos para a guerra. A tribo interpretou os raios como um apoio dos deuses para a batalha.",

            new Events[] { Events.S6A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S6B] = new Event(
            defaultImg,
            "Em uma reunião com a tribo aliada, estavam sendo decididas as estratégias de ataque para vencer a guerra. Para maximizar a força, era um consenso focar em apenas uma das várias cogitadas. Qual tática usar?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Atacar imediatamente", Events.S6B1),
                new Option("Usar o terreno ao seu favor", Events.S6B2),
                new Option("Intimidar com uma invocação aos deuses", Events.S6B3)
            }
        );

        events[(int)Events.S6B1] = new Event(
            defaultImg,
            "Um ataque imediato já era esperado pelos seus inimigos. Sua habilidade militar apenas amenizou a perda de guerreiros e mantimentos. O fracasso na batalha foi um dos piores fardos que sua tribo terá de carregar.",

            new Events[] { },
            0, 0, 0,
            -1, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S6B1Log] = new Event(
            defaultImg,
            "Outros ataques aconteceram em um curto período de tempo. Com os guerreiros desestabilizados após o fracasso da última investida, muitos recursos se foram.",

            new Events[] { Events.S6B1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S6B2] = new Event(
            defaultImg,
            "Os seus inimigos não esperavam a habilidade que teriam dentro de seu próprio território. Com movimentos rápidos e sucintos, não foram capazes apenas de vencer a guerra.",

            new Events[] { },
            0, 0, 0,
            1, 0, 1,
            new Option[] { }
        );

        events[(int)Events.S6B2Log] = new Event(
            defaultImg,
            "A tribo aliada enviou um presente a sua para agradecer a ajuda na luta contra o inimigo. Laços fortes entres os povos estão se firmando.",

            new Events[] { Events.S6B2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S6B3] = new Event(
            defaultImg,
            "A fé de sua tribo era muito maior do qualquer inimigo poderia esperar. Uma grande cerimônia foi realizada dias antes do ataque, intimidando completamente os atacantes. Uma parte deles ainda se converteu e foi morar em um pequeno clã amigo.",

            new Events[] { },
            0, 0, 0,
            1, 0, 1,
            new Option[] { }
        );

        events[(int)Events.S6B3Log] = new Event(
            defaultImg,
            "A tribo aliada enviou um presente a sua para agradecer a ajuda na luta contra o inimigo. Laços fortes entres os povos estão se firmando.",

            new Events[] { Events.S6B3 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S3A] = new Event(
            defaultImg,
            "O chefe de um dos mais importantes clãs da tribo decide arrumar um casamento para a sua filha. Alguns conselheiros apontam um homem da própria tribo como um esposo ideal, enquanto outros sugerem um vindo da tribo vizinha. O que fazer?",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Um membro da própria tribo", Events.S3A1),
                new Option("Um membro da tribo vizinha", Events.S3A2)
            }
        );

        events[(int)Events.S3A1] = new Event(
            defaultImg,
            "Com o pretendente escolhido e tudo acertado entre as famílias, os preparativos começariam em breve.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S3A1Log] = new Event(
            defaultImg,
            "Um bonito ritual foi feito como noivado para o casal. Os sacerdotes da tribo pediam aos deuses um casamento sólido em meio a um verdadeiro banquete.",

            new Events[] { Events.S3A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S3A2] = new Event(
            defaultImg,
            "Com o pretendente escolhido e tudo acertado entre as famílias, os preparativos começariam em breve.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S3A2Log] = new Event(
            defaultImg,
            "Um bonito ritual foi feito como noivado para o casal. Os sacerdotes da tribo pediam aos deuses um casamento sólido em meio a um verdadeiro banquete.",

            new Events[] { Events.S3A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
	
		events[(int)Events.S3B] = new Event(
            defaultImg,
            "Para comemorar o casamento que iria acontecer em breve, uma cerimônia seria realizada, mas os pais dos noivos não entravam em consenso quanto a ela. A família da noiva queria algo mais reservado, apenas para os chefes dos clãs, enquanto a do noivo queria uma grande comemoração popular. O que fazer?",

            new Events[] { Events.S3A1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Festa reservada", Events.S3B1),
                new Option("Comemoração popular", Events.S3B2)
            }
        );

        events[(int)Events.S3B1] = new Event(
            defaultImg,
            "Por mais que a festa tenha sido um verdadeiro exemplo de fartura, um sentimento amargo compadeceu no povo, que ficou excluído e se sentiu inferior diante a um acontecimento tão importante.",

            new Events[] { },
            0, 0, 0,
            0, 0, -1,
            new Option[] { }
        );

        events[(int)Events.S3B1Log] = new Event(
            defaultImg,
            "Uma grande mobilização popular aconteceu semanas depois, para comemorar um casamento entre dois camponeses. Mesmo modesta, a festa não contou com a presença dos chefes.",

            new Events[] { Events.S3B1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S3B2] = new Event(
            defaultImg,
            "A festa parecia uma verdadeira cerimônia aos deuses, dada a beleza e a fartura da comemoração. Um verdadeiro sentimento de alegria tomou a tribo por semanas.",

            new Events[] { },
            0, 0, 0,
            0, 0, 1,
            new Option[] { }
        );

        events[(int)Events.S3B2Log] = new Event(
            defaultImg,
            "Uma grande mobilização popular aconteceu anos depois, para comemorar o nascimento do filho mais velho do casal.",

            new Events[] { Events.S3B2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.S3C] = new Event(
            defaultImg,
            "Como parte do acordo de casamento entre os clãs, as tribos deveriam enviar uma espécie de grande presente. Alguns sábios sugeriam uma grande leva de recursos, enquanto outros achavam que a presença do próprio clã na outra tribo seria o melhor presente possível. O que fazer?",

            new Events[] { Events.S3A2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] {
                new Option("Enviar recursos", Events.S3C1),
                new Option("Mudar o clã para a outra tribo", Events.S3C2)
            }
        );

        events[(int)Events.S3C1] = new Event(
            defaultImg,
            "O presente foi muito bem recebido e aceito na tribo vizinha, que se encarregou de fazer uma grande cerimônia, tanto em beleza, quanto em representação de poder.",

            new Events[] { },
            0, 0, 0,
            0, -1, 0,
            new Option[] { }
        );

        events[(int)Events.S3C1Log] = new Event(
            defaultImg,
            "O casamento foi uma festa que ficaria guardada na memória de todos os presentes para o resto de sua vida. Nunca tinha-se visto tanta beleza e fartura.",

            new Events[] { Events.S3C1 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S3C2] = new Event(
            defaultImg,
            "A instalação do clã na outra tribo, após a belíssima festa de casamento, ocorreu sem problemas e acabou por firmar, de forma mais consistente, a aliança entre as tribos.",

            new Events[] { },
            0, 0, 0,
            -1, 0, 0,
            new Option[] { }
        );

        events[(int)Events.S3C2Log] = new Event(
            defaultImg,
            "O casamento foi uma festa que ficaria guardada na memória de todos os presentes para o resto de sua vida. Nunca tinha-se visto tanta beleza e fartura.",

            new Events[] { Events.S3C2 },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		// good endings
		
		events[(int)Events.GoodEndReli] = new Event(
            defaultImg, // COLOCAR IMAGEM DE FINAL RELIGIOSO
            "A fé nos deuses deixou de estar presente apenas naquela região. Espalhando-se por todo o continente, a sua doutrina atravessou oceanos e planícies. para conquistar todo o planeta. Sua tribo tornou-se o maior centro religioso do mundo, levando, juntamente com a sua crença de bons valores, alienação, intolerância e a morte de milhões de pessoas que não acreditavam no poder das entidades.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.GoodEndMerc] = new Event(
            defaultImg, // COLOCAR IMAGEM DE FINAL MERCANTIL
            "O comércio tornou-se o motor da sua sociedade. Novas técnicas e tecnologias foram desenvolvidas, maximizando a produção de forma exorbitante. A busca por novos mercados levou a sua tribo a tornar-se uma verdadeira potência dos mares, independente do preço a se pagar por isso. Milhares de pessoas vivem, todos os dias, em meio a uma hierarquia econômica opressora e que transforma suas próprias vidas em lucro.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.GoodEndMili] = new Event(
            defaultImg, // COLOCAR IMAGEM DE FINAL MILITAR
            "A sua sociedade foi forjada no ferro das espadas e dos escudos. O maior exército já visto foi o responsável pela expansão territorial do que viria a se tornar um verdadeiro império. Em meio ao sangue de guerreiros e inocentes, sua tribo tornou-se a maior potência militar do mundo e é capaz de controlá-lo apenas pela eficiência de suas tropas.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		// bad endings
		// trigger: falta de pessoas
		
		events[(int)Events.BadEndPess] = new Event(
            defaultImg, 
            "Depois de muitas derrotas em guerras e fugas descontroladas, a população de sua tribo reduziu-se a apenas algumas dúzias de pessoas.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.BadEndPess2] = new Event(
            defaultImg, 
            "Pode-se contar com as mãos os que ainda plantam para tentar sobreviver — a caça deixou de ser uma opção. A fome acompanha a tribo a cada noite.",

            new Events[] { Events.BadEndPess },
            0, 0, 0,
            0, -6, 0,
            new Option[] { }
        );
		
		events[(int)Events.BadEndPess3] = new Event(
            defaultImg, // COLOCAR IMAGEM DE BAD ENDING
            "Os poucos que sobraram quase não tem mais comida, depois de ferrenhas lutas entre si. Sem pessoas, recursos ou sentimentos de esperança, sua tribo sofreu um ataque de um povo guerreiro do Leste. Todos foram dominados e escravizados.",

            new Events[] { Events.BadEndPess },
            0, 0, 0,
            0, 0, -6,
            new Option[] { }
        );
		
		// trigger: falta de recursos		
		events[(int)Events.BadEndRecu] = new Event(
            defaultImg, 
            "Os tempos de fartura são apenas história. Uma má administração dos alimentos, seguida de muitos saques feitos por outros povos, levou à uma desoladora fome, que assombrava a tribo desde então.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.BadEndRecu2] = new Event(
            defaultImg, 
            "Aos poucos, a população da tribo diminuiu consideravelmente. Os poucos que ainda comiam lutavam por sua sobrevivência, mas todo o esforço parecia em vão.",

            new Events[] { Events.BadEndRecu },
            0, 0, 0,
            -6, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.BadEndRecu3] = new Event(
            defaultImg, // COLOCAR IMAGEM DE BAD ENDING
            "Reduzidos em um precário abrigo, a tribo perdia, todas as semanas, mais um membro em lutas internas. Sem pessoas, recursos ou sentimentos de esperança, sua tribo sofreu um ataque de um povo guerreiro do Sul. Todos foram dominados e escravizados.",

            new Events[] { Events.BadEndRecu },
            0, 0, 0,
            0, 0, -6,
            new Option[] { }
        );
		
		// trigger: falta de moral
		events[(int)Events.BadEndMora] = new Event(
            defaultImg, 
            "Os clãs que compunham a tribo entraram em um estado extremo de tensão. Assasinatos ocorriam todos os dias, o desentendimento tornava-se sangue derramado. A tribo quebrou-se completamente.",

            new Events[] { },
            0, 0, 0,
            0, 0, 0,
            new Option[] { }
        );
		
		events[(int)Events.BadEndMora2] = new Event(
            defaultImg, 
            "Separados e enfurecidos, a produção de alimentos decaía a cada semana que se passava. Os que não haviam morrido nas lutas, começavam a padecer de fome.",

            new Events[] { Events.BadEndMora },
            0, 0, 0,
            0, -6, 0,
            new Option[] { }
        );
		
		events[(int)Events.BadEndMora3] = new Event(
            defaultImg, // COLOCAR IMAGEM DE BAD ENDING
            "Com a redução quase total da população, a tribo tentou se reunir, mas a situação apenas piorou. Sem pessoas, recursos ou sentimentos de esperança, sua tribo sofreu um ataque de um povo guerreiro do Sul. Todos foram dominados e escravizados.",

            new Events[] { Events.BadEndMora },
            0, 0, 0,
            -6, 0, 0,
            new Option[] { }
        );
    }	
}