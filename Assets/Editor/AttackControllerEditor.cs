using UnityEditor;
using UnityEngine;
using System.Collections;


[CustomEditor(typeof(attackController))]
public class AttackControllerEditor : Editor
{


    // These are here so i dont have to use OOP >:(
    SerializedProperty attackType;
    AttackType attackTypeEdit;
    SerializedProperty canAttackEdit;
    SerializedProperty shouldAttackEdit;
    SerializedProperty  attackKeyEdit;
    SerializedProperty lastKeyPressedEdit;
    SerializedProperty attackPointsEdit;   
    SerializedProperty  swordAttackDamageEdit;
    SerializedProperty swordTimeBetweenAttackEdit;
    SerializedProperty  bowAttackDamageEdit;
    SerializedProperty bowTimeBetweenAttackEdit;
    SerializedProperty  axeAttackDamageEdit;
    SerializedProperty  axeTimeBetweenAttackEdit;
    SerializedProperty  pickaxeAttackDamageEdit;
    SerializedProperty pickaxeTimeBetweenAttackEdit;
    SerializedProperty  isRangedEdit;
    SerializedProperty timeBetweenAttackEdit;
    SerializedProperty  attackDamageEdit;

    bool swordAttack,  bowAttack, axeAttack, pickaxeAttack, attack;

    void OnEnable() {
        
        
        canAttackEdit = serializedObject.FindProperty("canAttack");
        shouldAttackEdit = serializedObject.FindProperty("shouldAttack");
        attackKeyEdit = serializedObject.FindProperty("attackKey");
        lastKeyPressedEdit = serializedObject.FindProperty("lastKeyPressed");
        attackPointsEdit = serializedObject.FindProperty("attackPoints");
        timeBetweenAttackEdit = serializedObject.FindProperty("timeBetweenAttack");
        swordAttackDamageEdit = serializedObject.FindProperty("swordAttackDamage");
        swordTimeBetweenAttackEdit = serializedObject.FindProperty("swordTimeBetweenAttack");
        bowAttackDamageEdit = serializedObject.FindProperty("bowAttackDamage");
        bowTimeBetweenAttackEdit = serializedObject.FindProperty("bowTimeBetweenAttack");
        axeAttackDamageEdit = serializedObject.FindProperty("axeAttackDamage");
        axeTimeBetweenAttackEdit = serializedObject.FindProperty("axeTimeBetweenAttack");
        pickaxeAttackDamageEdit = serializedObject.FindProperty("pickaxeAttackDamage");
        pickaxeTimeBetweenAttackEdit = serializedObject.FindProperty("pickaxeTimeBetweenAttack");
        isRangedEdit = serializedObject.FindProperty("isRanged");
        attackDamageEdit = serializedObject.FindProperty("attackDamage");
        




        attackType = serializedObject.FindProperty("attackType");
    }

    public override void OnInspectorGUI()
    {

        attackController attackControl = (attackController)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(attackType);

        #region Sword Attack    
        if(attackControl.attackType == AttackType.Sword)
        {
            EditorGUILayout.Space(10);
            swordAttack = EditorGUILayout.BeginFoldoutHeaderGroup(swordAttack, "Sword Damage");
            
            


            if(swordAttack){
                EditorGUILayout.PropertyField(swordAttackDamageEdit);
                EditorGUILayout.PropertyField(swordTimeBetweenAttackEdit);
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
            
        }
        
        
        
        #endregion
        #region Bow Attack
        
        if(attackControl.attackType == AttackType.Bow){
            EditorGUILayout.Space(10);
            bowAttack = EditorGUILayout.BeginFoldoutHeaderGroup(bowAttack, "Bow Damage");
            

            if(bowAttack){
                EditorGUILayout.PropertyField(bowAttackDamageEdit);
                EditorGUILayout.PropertyField(bowTimeBetweenAttackEdit);
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        

        #endregion
        #region Axe Attack
        
        if(attackControl.attackType == AttackType.Axe){
            EditorGUILayout.Space(10);

            axeAttack = EditorGUILayout.BeginFoldoutHeaderGroup(axeAttack, "Axe Damage");
            

            if(axeAttack){
                EditorGUILayout.PropertyField(axeAttackDamageEdit);
                EditorGUILayout.PropertyField(axeTimeBetweenAttackEdit);
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
        }
        

        #endregion
        #region Pickaxe Attack
        
        if(attackControl.attackType == AttackType.Pickaxe){
            EditorGUILayout.Space(10);
            pickaxeAttack = EditorGUILayout.BeginFoldoutHeaderGroup(pickaxeAttack, "Pickaxe Damage");
            
            

            if(pickaxeAttack)
            {
                EditorGUILayout.PropertyField(pickaxeAttackDamageEdit);
                EditorGUILayout.PropertyField(pickaxeTimeBetweenAttackEdit);
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
        }   
        
        
        #endregion
        #region None
            if(attackControl.attackType == AttackType.None)
            {
                EditorGUILayout.Space(10);
                EditorGUILayout.LabelField("You cannot attack right now");
                EditorGUILayout.Space(10);
              

            }
        #endregion

        #region Attack

            attack = EditorGUILayout.BeginFoldoutHeaderGroup(attack, "Attack");

            if(attack){
                EditorGUILayout.PropertyField(attackDamageEdit);
                EditorGUILayout.PropertyField(timeBetweenAttackEdit);
            }
            

        #endregion

        serializedObject.ApplyModifiedProperties();

    }
}
