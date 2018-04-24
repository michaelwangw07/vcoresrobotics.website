import { Component, Injector, ViewChild } from '@angular/core';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { PostServiceProxy, PostListDto, ListResultDtoOfPostListDto, EntityDtoOfGuid } from '@shared/service-proxies/service-proxies';
import { PagedListingComponentBase, PagedRequestDto } from "shared/paged-listing-component-base";
import { CreatePostComponent } from "app/posts/create-post/create-post.component";

@Component({
    templateUrl: './posts.component.html',
    animations: [appModuleAnimation()]
})
export class PostsComponent extends PagedListingComponentBase<PostListDto> {

    @ViewChild('createPostModal') createPostModal: CreatePostComponent;

    active: boolean = false;
    posts: PostListDto[] =[] ;

    constructor(
        injector: Injector,
       private _postService: PostServiceProxy
    ) {
        super(injector);
    }

    protected list(request: PagedRequestDto, pageNumber: number, finishedCallback: Function): void {
        this.loadPost();
        finishedCallback();
    }

    protected delete(posts: EntityDtoOfGuid): void {
        abp.message.confirm(
            'Are you sure you want to cancel this post?',
            (result: boolean) => {
                if (result) {
                   
                }
           }
       );
    }

    // Show Modals
    createPost(): void {
        this.createPostModal.show();
    }


    loadPost() {
       this._postService.getPostListAsync()
           .subscribe((result: ListResultDtoOfPostListDto) => {
               this.posts = result.items;
            });
    }

}