var vitesse : float = 0.0;

function Update () {

  transform.Translate(Vector3(0, vitesse * Time.deltaTime, 0));
}
