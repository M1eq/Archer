using Spine;
using Spine.Unity;
using UnityEngine;

public class ArcherAnimationLauncher : MonoBehaviour
{
    [SerializeField] private SkeletonAnimation _skeletonAnimation;
    [Space(10), SerializeField] private AnimationReferenceAsset _aimAnimation;
    [SerializeField] private AnimationReferenceAsset _reloadAnimation;
    [SerializeField] private AnimationReferenceAsset _shootAnimation;
    [SerializeField] private AnimationReferenceAsset _idleAnimation;

    [Space(10), SpineBone(dataField: "skeletonAnimation")]
    [SerializeField] private string _boneName;
    [SerializeField] private Camera _mainCamera;

    private AnimationReferenceAsset _currentAnimation;
    private Bone _targetBone;

    private bool CanUpdateTargetBoneRotation => _currentAnimation == _aimAnimation && _targetBone != null;
    public void InitializeTargetBone() => _targetBone = _skeletonAnimation.Skeleton.FindBone(_boneName);
    public void LaunchShootAnimation() => LaunchAnimation(_shootAnimation, false);
    public void LaunchIdleAnimation() => LaunchAnimation(_idleAnimation, true);
    public void LaunchAimAnimation() => LaunchAnimation(_aimAnimation, false);

    public void TryUpdateTargetBoneRotation()
    {
        if (CanUpdateTargetBoneRotation)
        {
            var mousePosition = Input.mousePosition;
            var worldMousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);

            Vector2 targetDir = _skeletonAnimation.transform.position - worldMousePosition;
            float angleBetween = Vector2.SignedAngle(targetDir, Vector2.right);

            _targetBone.Rotation = -angleBetween;
        }
    }

    private void LaunchAnimation(AnimationReferenceAsset animation, bool loop)
    {
        _skeletonAnimation.AnimationState.SetAnimation(0, animation, loop);
        _currentAnimation = animation;
    }
}

