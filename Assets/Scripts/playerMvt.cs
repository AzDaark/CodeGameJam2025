using TMPro;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class CarController : MonoBehaviour
{
    public float laneWidth = 4.5f; // Largeur entre les voies
    public int currentLane = 1; // Voie actuelle (0 = gauche, 1 = centre, 2 = droite)
    public float transitionSpeed = 6.0f; // Vitesse de transition
    private Vector3 targetPosition; // Position cible

    public AudioSource laneChangeSound;

    private Quaternion targetRotation; // Rotation cible
    private float tiltAngle = 70f; // Angle d'inclinaison lors du changement de voie

    void Start()
    {
        // Initialise la position et la rotation cibles
        targetPosition = transform.position;
        targetRotation = transform.rotation;
        // Vérifie si l'AudioSource est assignée
        if (laneChangeSound == null)
        {
            laneChangeSound = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        HandleInput();
        MoveToTargetLane();
    }

    void HandleInput()
    {
        // Vérifie les touches pour changer de voie
        if (Input.GetKeyDown(KeyCode.LeftArrow) && currentLane > 0)
        {
            currentLane--; // Déplace à gauche
            targetRotation = Quaternion.Euler(0, 0, tiltAngle); // Incline à gauche
            TriggerLaneChangeSound();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && currentLane < 2)
        {
            currentLane++; // Déplace à droite
            targetRotation = Quaternion.Euler(0, 0, -tiltAngle); // Incline à droite
            TriggerLaneChangeSound();
        }
        else
        {
            targetRotation = Quaternion.Euler(0, 0, 0); // Retour à la position normale
        }

        // Met à jour la position cible
        targetPosition = new Vector3(currentLane * laneWidth - laneWidth, transform.position.y, transform.position.z);
    }
    
    void TriggerLaneChangeSound()
    {
        // Si le son est déjà en cours, arrête-le avant de rejouer
        if (laneChangeSound.isPlaying)
        {
            laneChangeSound.Stop();
        }

        laneChangeSound.Play(); // Joue le son
    }
    
    void MoveToTargetLane()
    {
        // Déplacement progressif vers la position cible
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * transitionSpeed);

        // Rotation progressive vers la rotation cible
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * transitionSpeed);

    }
    void OnCollisionEnter(Collision collision)
    {
        // Vérifier si l'objet touché est un obstacle ou un objet auquel vous souhaitez réagir
        if (collision.gameObject.CompareTag("Obstacle"))  // Assurez-vous que l'objet a bien le tag "Obstacle"
        {
            // Afficher un message de fin de jeu
            Debug.Log("Game Over!");

            // Arrêter le jeu (pause)
            Time.timeScale = 0f;  // Le temps s'arrête, simulant la fin du jeu

            // Ou vous pouvez charger une scène de fin de jeu
            // UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");

            // Si vous voulez simplement détruire la voiture
            // Destroy(gameObject);  // Détruire la voiture
        }
    }

}
