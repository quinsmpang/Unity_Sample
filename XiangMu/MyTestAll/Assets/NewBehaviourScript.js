private var Regression : Vector3;
public var Player_Prefab : Transform;
public var Enemy_State : String;
public var Doing : boolean = true;
public var Range : float = 4.0;
public var Bullet : Transform;
public var Bullet_Prefab : Transform;
//初始化敌人方向和位置
function Start()
{
    transform.localEulerAngles.y = Random.value * 360;
    Regression = transform.position;
}
//敌人行动模式
public var Thinking : boolean = true;
public var Thinking_Time : float = 1.0;
private var relativePos : Vector3;
private var rotation : Quaternion;
public var Facing : boolean = false;
public var Facing_Time : float = 2.0;
public var Facing_Speed : float = 2.0;
public var Moving : boolean = false;
public var Moving_Speed : float = 0.5;
public var Moving_Time : float = 4.0;
public var Moving_Back : boolean = false;
public var Attacking : boolean = false;
private var Bullet_DO : boolean = true;
public var Bullet_CD : float = 0.2;
//随机移动方位
private var R_Position : Vector3;
function Update () 
{
    if(Attacking)
    {
        Enemy_State = "Attacking";
        Facing = true;
        Moving = true;
        //Doing = true;
        Thinking = false;
        var dist2 = Vector3.Distance(Regression, transform.position);
        if(dist2 > 20)
        {
            relativePos = Regression - transform.position;
            rotation = Quaternion.LookRotation(relativePos);
            Attacking = false;
            Moving_Back = true;
        }
    }
    if(!Moving_Back)
    {
        var dist = Vector3.Distance(Player_Prefab.position, transform.position);
        if(dist > 100)
        {
            Attacking = false;
            return;
        }
        else if(dist < 5)
        {
            Attacking = true;
        }
        RayJudge();
    }
    transform.localEulerAngles.x = 0;
    transform.localEulerAngles.z = 0;
    if(Thinking && !Attacking && !Moving_Back)
    {
        Enemy_State = "Thinking";
        if(Doing)
        {
            StartCoroutine(Think(Thinking_Time));
            Doing = false;
        }
    }
    if(Facing)
    {
        Enemy_State = "Facing";
        if(Attacking)
        {
            relativePos = Player_Prefab.position - transform.position;
            rotation = Quaternion.LookRotation(relativePos);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Facing_Speed * 4);
        }
        else if(Moving_Back)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Facing_Speed * 4);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * Facing_Speed);
            if(Doing)
            {
                StartCoroutine(Face(Facing_Time)); 
                Doing = false;
            }
        }
    }
    if(Moving)
    {
        Enemy_State = "Moving";
        if(Moving_Back)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Moving_Speed * 6);
        }
        else if(dist > 2)
        {
            if(Attacking)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Moving_Speed * 4);
            }
            else
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Moving_Speed);
            }
        }
        if(Doing && !Attacking)
        {
            StartCoroutine(Move(Moving_Time));
            Doing = false;
        }
    }
}
//前方锁敌
function RayJudge()
{
    var layerMask = 1 << 2;
    layerMask = ~layerMask;
    var hit : RaycastHit;
    if(Physics.Raycast (transform.position, transform.TransformDirection(Vector3.forward), hit, 20,layerMask)) 
    {
        var distanceToForward = hit.distance;
        if(hit.transform.tag == "Player")
        {
            Attacking = true;
            if(Bullet_DO)
            {
                var Create = Instantiate (Bullet_Prefab, Bullet.position, Quaternion.identity);
                Create.GetComponent.<Rigidbody>().AddForce (Bullet.forward * 1000);
                StartCoroutine(Wait(Bullet_CD)); 
                Bullet_DO = false;
            }
        }
    }
}
function Wait(waitTime : float)
{
    yield WaitForSeconds (waitTime);
        Bullet_DO = true;
    }
    function Move(waitTime : float)
        {
            print("Move");
            if(Moving_Back)
            {
                yield WaitForSeconds (waitTime * 0.4); 
            }
            else
            {
                yield WaitForSeconds (waitTime + Random.value * 2); 
            }
            Thinking = true;
            Moving_Back = false;
            Moving = false;
            Facing = false;
            Doing = true;
        }
        function Face(waitTime : float)
            {
                print("Face");
                yield WaitForSeconds (waitTime + Random.value);
                Facing = false;
                Thinking = false;
                Moving = true;
                Doing = true;
            }
            function Think(waitTime : float)
                {
                    print("Thinking");
                    yield WaitForSeconds (waitTime + Random.value);
                    R_Position = Regression + Random.insideUnitSphere * Range;
                    R_Position.y = Regression.y;
                    relativePos = R_Position - transform.position;
                    rotation = Quaternion.LookRotation(relativePos);
                    Thinking = false;
                    Moving = false;
                    Facing = true;
                    Doing = true;
                }
