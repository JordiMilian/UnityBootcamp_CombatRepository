using UnityEngine;

public class NotasBootcamp : MonoBehaviour
{
    /*
    SHORTCUTS UNITY
        - Ctrl + Shift + F: Ajustar objeto a camara
    SHORTCUTS VISUAL STUDIO
        - Ctrl + R + M : Build a Method with the selected code

    05/05/2025
        Cinemachine: Cambiar el int PRIORITY de una cámara para que la Main Camera se mueva hacia ahi. Se lleva la camera el que tenga mayor proiority.

        GUID: es un numero en el .meta que identifica el asset, es un numero unico que se genera al crear el asset.

        Para extraer texturas de un FBX vete al inpector > materials > extract textures
        Lo mismo para los materials si los quieres modificar
        Al extraer texturas, asegurate de que la textura de Normals este en modo Normal

    07/05/2025
        - Quaternion shit
        Un quaternion es una rotacion. Si lo multiplicas por el transform.rotation, le aplica la rotacion. Si lo seteas, lo reemplaza.
        - Al multiplicar el transform.rotation por un quaternion, el orden importa. Mejor hacer transform.rotation = Quaternion * transform.rotation
        - Quaternion.AngleAxis es muy util para generar una rotacion en torno a un eje como si fuese un Euler

        - Dividir una animacion a cachos
        -Anar a la animacio i fer clips
        - Animator > Substate machine  es como una subrutina. Es basicament pa limpiar telaraña de animator, pero no te molt mes. no canvie la logica

        - Package manager Animation Rigging pa visualitzar bones
        - Parent Constrain esta molt be pa simular pare/fill sense gerarquia

    12/05/2025
        -Modelo Vista Controlador MVC
    SOLID
        1-  SIngle use
        2- Open /close
        3- Liskob Clase arma, herede clase que pots tocar una canço, pero el manager no ha de saber sobre l'arma en concret, sino que el base ha de implementar canço?


    14/05/2025
    BreakPoints for debug:
F9 - create break point
F10 - go to next line
F11 para entrar en los detalles de una linea
F5 continue playing in Unity
Configuracion del punto de interrupcion
     - Funcion lambas, muy util para DOtween () => float variable
    DOTWEEN es en esencia una sola funcion Dotween.TO() que luego se modifica y tal
    Append - una funcio detras de una altra
    Join - se realiza a la vez
    Insert - comence en un punto en concreto
    OnComplete - llamar una funcion cuando se complete
    AppendCallback pa meter una funcion normal donde quiera
    DOMove().SetRelative - moure en relatiu
    DOMove().SetSpeedbase - moure en relatiu
    seq.Kill() - cortar una sequencia
    Ojo con el Time.scale, depen de quina funcion pot ser que ignore el TimeScale


    COMPONENTE EVENT TRIGGER
        Pa que un element de UI pugue interactuar amb el canvas i tal i detectar coses. Per exemple, ficarli events a un boto OnEnterMouse apart del defaul OnClick


    Pa meterle eventos a un animation(Read only) cuidado metelo desde el inspector


    Potser hauries de tenir un partida controller, partida view, partida Model



    19/05/2025
        - Debug.log("string", component) te permet que al debug se faci highlight del segon parameter en escena
        - Serializacion: COnvertir un fixeron en YAML? NOse
    - Save and Save Projects son dos coses (el primer salve la escena)
    - Object i object no es lo mateix



    21/05
    BItWise logic
    && and
    || or
    true and false = true   1 & 1 = 1
    false and true = false  0 & 1 = 0
    false and true = false  1 & 0 = 0
    false and false = false 0 & 0 = 0

    LayerMask  --> Integer de 32 bits que representa FLAGS (encendido o apagago)
    
    000000000000000000000  <-- 32 zeros

    << --> desplaçar el binari tantes unitats el 1
    1 << 4 =  10000

    & , | , ^ , ~


     */


}
